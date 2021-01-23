    protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(ship, shipposition, Color.White);
            foreach (bullets bullet in bullets)
                bullet.Draw(spriteBatch);
            spriteBatch.End(); //Move to here instead
            base.Draw(gameTime);
        }
