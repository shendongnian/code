    public bool IsNewKeyPress(Keys key)
    {
        return (kbState.IsKeyDown(key) &&
             oldKbState.IsKeyUp(key));
    }
    
    // And in the update method...
    public void Update(GameTime gameTime)
    {
        oldKbState = kbState;
        kbState = Keyboard.GetState();
        if (IsNewKeyPress(Keys.A))
        {
            // A was *just* pressed
        }
        // ...
    }
