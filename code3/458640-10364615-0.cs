    protected override void Update(GameTime gameTime)
    {
        // Allow the game to exit.
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
        // Update the paddles according to the keyboard.
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
            PongPaddle1.Y -= paddleSpeed;
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
            PongPaddle1.Y += paddleSpeed;
        // Update the paddles according to the safe bounds.
        var safeTop = safeBounds.Top - 30;
        var safeBottom = safeBounds.Bottom - 70;
        PongPaddle1.Y = MathHelper.Clamp(PongPaddle1.Y, safeTop, safeBottom);
        PongPaddle2.Y = MathHelper.Clamp(PongPaddle2.Y, safeTop, safeBottom);
        // Allow the base to update.
        base.Update(gameTime);
    }
