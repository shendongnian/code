    protected override void Update(GameTime gameTime)
    {
        // Allows the game to exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
        //Allows the player to move
        character.Update();
        // TODO: Add your update logic here
        base.Update(gameTime);
    }
