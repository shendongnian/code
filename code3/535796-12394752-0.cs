    protected override void Draw(GameTime gameTime)
    {
        randomer = new Random(seed);   
        GraphicsDevice.Clear(Color.White);
        spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
        if (counter < 10)
        {
            for (int i = 0; i < 10; i++)
            {
                spriteBatch.Draw(turtleTexture, new Vector2(randomera.Next(600), randomera.Next(400)),
                    Color.Black);
                counter++;
            }
        }
        spriteBatch.End();
        base.Draw(gameTime);
    }
