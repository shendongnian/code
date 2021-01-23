    public void Update(GameTime gameTime)
    {
        keyState_old = keyState;  // Do this first
        keyState = Keyboard.GetState();  // Then this
        mouseState = Mouse.GetState();
        //Updates some other stuff within the class here, unrelated to keyboard input
    }
