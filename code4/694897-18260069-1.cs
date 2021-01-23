    private void HandleMouse(GameTime gameTime)
    {
        currentMouseState = Mouse.GetState();
        float amount = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
        if (currentMouseState.X != screenCenter.X)
        {
            yaw -= YrotationSpeed * (currentMouseState.X - screenCenter.X) * amount;
        }
        if (currentMouseState.Y != screenCenter.Y)
        {
            pitch -= XrotatiobSpeed * (currentMouseState.Y - screenCenter.Y) * amount;
            if (pitch > MathHelper.ToRadians(90))
                pitch = MathHelper.ToRadians(90);
            if (pitch < MathHelper.ToRadians(-50)) //Preventing the user from looking all the way down (and seeing the character doesn't have any legs..)
                pitch = MathHelper.ToRadians(-50);
        }
        Mouse.SetPosition((int)screenCenter.X, (int)screenCenter.Y);
    }
