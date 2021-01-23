        public class Player
        {
          private Vector2 Velocity, Position;
          private bool is_jumping; 
          private const float LandPosition = 500f; 
          public Player(Vector2 Position)
          {
             this.Position = new Vector2(Position.X, LandPosition); 
             Velocity = Vector2.Zero;
             is_jumping = false; 
          }
          public void UpdatePlayer(Gametime gametime, KeyboardState keystate, KeyboardState previousKeyBoardState)
          {
           if (!is_jumping)
             if (keystate.isKeyDown(Keys.Space) && previousKeyBoardState.isKeyUp(Keys.Space))
              do_jump(10f); 
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
