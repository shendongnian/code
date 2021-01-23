       public void Jump(GameTime gameTime)
       {
           if(jumping && position.Y > groundLevelAtPlayer) {
               //Get the total time since the jump started
               float currentTime = gameTime.totalTime - character.timeofjumpStart;
               //gravity should be a negative number, so add it
               position.Y += (velocity.Y * currentTime)
                   + (gravity * ((float)(Math.Pow(currentTime, 2)) / 2));
           }
           else 
           {
               jumping = false;
           }
       }
