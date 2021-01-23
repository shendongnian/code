    private const float HOLD_TIMESPAN = .5f; //must hold down mouse for 1/2 sec to activate hold
    MouseState current, last;
    private float holdTimer;
    
    public virtual void Update(GameTime gameTime)
    {
        bool isHeld, isClicked; //start off with some flags, both false
        last = current; //store previous frame's mouse state
        current = Mouse.GetState(); //store this frame's mouse state
        if (current.LeftButton == ButtonState.Pressed)
        {
            holdTimer += (float)gameTime.ElapsedTime.TotalSeconds();
        }
        if (holdTimer > HOLD_TIMESPAN)
            isHeld = true;
        if (current.LeftButton == ButtonState.Released)
        {
            if (isHeld) //if we're releasing a held button
            {
                holdTimer = 0f; //reset the hold timer
                isHeld = false;
                OnHoldRelease(); //do anything you need to do when a held button is released
            }
            else if (last.LeftButton == ButtonState.Pressed) //if NOT held (i.e. we have not elapsed enough time for it to be a held button) and just released this frame
            {
                //this is a click
                isClicked = true;
            }
         }
         if (isClicked) VanishObject();
         else if (isHeld) MoveObject(current.X, current.Y);
     }
     
