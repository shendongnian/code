        public class Player
        {
          private Vector2 Velocity, Position;
      
          public Player(Vector2 Position)
          {
             this.Position = Position;
             Velocity = Vector2.Zero;
          }
          public void UpdatePlayer(Gametime gametime)
          {
           if (!is_jumping)
             if (keystate.isKeyDown(Keys.W) && previousKeyBoardState.isKeyUp(Keys.W))
              do_jump(speed); 
           else
           {
            Velocity.Y++; 
            if (Position.Y >= LandPosition)
               is_jumping = false; 
           } 
           Position += Velocity; 
           
         }
         private void do_jump(float speed)
         {
                is_jumping = true; 
                Velocity = new Vector2(Velocity.X, -speed); 
         }
       }
