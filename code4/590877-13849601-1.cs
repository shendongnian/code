    public override void Draw(SpriteBatch spriteBatch)
    {
       spriteBatch.Begin();
       spriteBatch.Draw(myTexture, new Vector2(320, 240), Color.White);
       spriteBatch.End();
    }
