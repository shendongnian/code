    SpriteBatch spriteBatch = ScreenManager.SpriteBatch; // singletion SpriteBatch
    spriteBatch.Begin();
    // Draw the background
    spriteBatch.Draw(background, ...
    foreach (var enemy in enemys)
    {
         enemy.Draw(gameTime);
    }
    // etc.
    spriteBatch.End(); // call here end 
    base.Draw(gameTime); // and then call the base class
