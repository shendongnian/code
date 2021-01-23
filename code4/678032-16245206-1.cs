    private void UpdateSheep(GameTime gameTime)
    {
            //How much time has passed since the last frame, incase we lag and skip a frame, or take too long, we can process accordingly
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
    
            if (currentKeyboardState.IsKeyDown(Keys.Left))
                sheep.SheepPosition.X -= SheepMoveSpeed * elapsed; // Multiply by elapsed!
            if (currentKeyboardState.IsKeyDown(Keys.Right))
                sheep.SheepPosition.X += SheepMoveSpeed * elapsed;
    }
