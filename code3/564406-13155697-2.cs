    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
        spriteBatch.Draw(ship, shipPos, Color.White);
        for (int alienCount = 0; alienCount < 20; alienCount++)
        {
            //draw alien texture for every aliensPos
            spriteBatch.Draw(alien, aliensPos[alienCount], Color.White);
        }
        for (int bulletCount = 0; bulletCount < 10; bulletCount++)
        {
            //draw bullet texture for every bulletsPos
            spriteBatch.Draw(bullet, bulletsPos[bulletCount], Color.White);
        }
        spriteBatch.End();
        base.Draw(gameTime);
    }
