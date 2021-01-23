    protected void Drive(GameTime gameTime) // Pass your game time
    {
        KeyboardState keyState = Keyboard.GetState();
        if (keyState.IsKeyDown(Keys.Up))
        {
            TruckSpeed += AccelerationRatePerSecond * gameTime.ElapsedGameTime.TotalSeconds;
        }
        else
        {
            TruckSpeed -= DecelerationRatePerSecond * gameTime.ElapsedGameTime.TotalSeconds;
        }
        MathHelper.Clamp(TruckSpeed, 0, 100);
        ...
