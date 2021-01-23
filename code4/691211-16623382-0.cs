    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
        map.Draw();  // first
        player.Draw();  // second
        spriteBatch.Draw(mouseIcon, mouseIconPosition, Color.White); // third
        spriteBatch.End();
        base.Draw(gameTime);
    }//end Draw()
