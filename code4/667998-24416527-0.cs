    velocity = Vector2.Zero;
    if (Keyboard.GetState().IsKeyDown(Keys.Right))
        velocity.X += 2;
    if (Keyboard.GetState().IsKeyDown(Keys.Left))
        velocity.X -= 2;
    if (Keyboard.GetState().IsKeyDown(Keys.Up))
        velocity.Y -= 2;
    if (Keyboard.GetState().IsKeyDown(Keys.Down))
        velocity.Y += 2;
    if (velocity.X > 0)
        AnimateRight(gameTime);
    else if (velocity.X < 0)
        AnimateLeft(gameTime);
    // Animate Up/Down only if Left/Right does not... 
    // not sure if needed but will follow the style.
    if (velocity.X == 0) 
    {
        if (velocity.Y > 0)
            AnimateDown(gameTime);
        else if (velocity.Y < 0)
            AnimateUp(gameTime);
    }
