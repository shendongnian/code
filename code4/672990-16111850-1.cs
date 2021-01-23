    double ClickTimer;
    const double TimerDelay = 500;
    
    public override void Update(GameTime gameTime)
    {
         ClickTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
         if(Mouse.GetState().LeftButton == ButtonState.Pressed)
         {
              if(ClickTimer < TimerDelay)
                  //this is a double click
              else
                  //this is a normal click
         
              ClickTimer = 0;
         }
    }
