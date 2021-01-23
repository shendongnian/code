    if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
    {
        position.Y -= spd * gameTime.ElapsedGameTime.TotalSeconds;
    }
    ...
