     private float timeSinceLastPush = 0;  
        public void Update(GameTime gameTime)
            {
                   var now = Keyboard.GetState();
                timeSinceLastPush +=(float)gameTime.ElapsedGameTime.TotalSeconds;
            
                 KeyboardState old = Keyboard.GetState();
          
           if (now.IsKeyDown(Keys.Down) && !old.IsKeyUp(Keys.Down)&& timeSinceLastPush >0.5 )
                {
                      properties.Menuposition++;
                        timeSinceLastPush = 0;
                         
                    }
                else if (now.IsKeyDown(Keys.Up) && !old.IsKeyUp(Keys.Up)&& timeSinceLastPush >0.5)
                    {
                        properties.Menuposition--;
                        timeSinceLastPush = 0;
                    }
                    else if (now.IsKeyDown(Keys.Enter)&& timeSinceLastPush >0.5)
                    {
                        properties.Menuposition = 5;
                        timeSinceLastPush = 0;
                    }
                    old = now;
                }
