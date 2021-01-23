    // define a frame counter
    private int mCounter;
    ...
    protected override void Update(GameTime pGameTime)
    {
       // save the elapsed time value
       float time = (float)pGameTime.ElapsedGameTime.TotalMilliseconds;
       ...
       // force a long frame every 2500th frame (change depending on your framerate)
       if (mCounter++ > 2500)
       {
          mCounter = 0;
          time = 75; // about 225 times longer frame
       }
       ...
       // use the time value in your move calls
       if ((keyboard.IsKeyDown(Keys.Left)) || (gamePad.DPad.Left == ButtonState.Pressed))
          mPlayer.MoveLeft(time);
