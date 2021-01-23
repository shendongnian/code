    protected override void Update(GameTime gameTime) 
    { 
        KeyboardState kbState = Keyboard.GetState(); 
        if (kbState.IsKeyDown(Keys.A)) 
        { 
        animation = new Animation(gegnerbilder, gegner, TimeSpan.FromSeconds(3)); 
        animation.Update(gameTime); 
        } 
        base.Update(gameTime); 
    } 
