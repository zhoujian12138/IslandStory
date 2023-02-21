using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private Rigidbody2D rb;

   public float speed;
   private float inputX;
   private float inputY;

   private Vector2 movementInput;

   private void Awake() 
   {
      rb = GetComponent<Rigidbody2D>();//初始时获取组件
   }

   private void Update() {
      PlayerInput();//持续获取movementInput
   }
   
   private void FixedUpdate() {//用于物理状态的更新
      Movement();
   }
   private void PlayerInput(){
      
      inputX = Input.GetAxisRaw("Horizontal");//获取键盘输入，a即-1，d即1
      inputY = Input.GetAxisRaw("Vertical");//s即-1，w即1

      if(inputX != 0 && inputY != 0)//角色斜着移动控制一下速度
      {
         inputX = inputX * 0.6f;
         inputY = inputY * 0.6f;
      }

      movementInput = new Vector2(inputX , inputY);
   }

   private void Movement(){
      rb.MovePosition(rb.position + movementInput * speed * Time.deltaTime );//利用刚体进行移动
   }
}
