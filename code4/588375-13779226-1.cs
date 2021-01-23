    protected override void Update(GameTime gameTime)
    {
      // snip...
    
      MouseState mouseState = Mouse.GetState();
    
      //Respond to the position of the mouse.
      //For example, change the position of a sprite 
      //based on mouseState.X or mouseState.Y
    
      //Respond to the left mouse button being pressed
      if (mouseState.LeftButton == ButtonState.Pressed)
      {
        //The left mouse button is pressed. 
      }
          
      base.Update(gameTime);
    }
