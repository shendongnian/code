    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(texture, new Rectangle(rand.Next(32,400),      yPos,32,32),Color.White);
        spriteBatch.End();
    
    }
