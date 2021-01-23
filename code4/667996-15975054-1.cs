        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            AnimateRight(gameTime);
            velocity.X = 2;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            AnimateLeft(gameTime);
            velocity.X = -2;
        }       
        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            AnimateUp(gameTime);
            velocity.Y = -2;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            AnimateDown(gameTime);
            velocity.Y = 2;
        }
        else velocity = Vector2.Zero;
