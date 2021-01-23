    if (!key.IsKeyDown(Keys.W) && !key.IsKeyDown(Keys.A) && !key.IsKeyDown(Keys.D) && !key.IsKeyDown(Keys.S))
    {
                 //Stop animation for player walking
                 animationPlayer.Update(new TimeSpan(0, 0, 0), true, Matrix.Identity);
    }
    else
    {
                 //Continue the animation 
                 animationPlayer.Update(gameTime.ElapsedGameTime, true, Matrix.Identity);
    }
