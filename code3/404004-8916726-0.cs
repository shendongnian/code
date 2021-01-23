    public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color overlayColor, float scale)
    {
        if (Garbage) return;
    
        DrawMe(gameTime, spriteBatch, overlayColor, scale);
    }
    protected abstract DrawMe(GameTime gameTime, spriteBatch SpriteBatch, Color overlayColor, float scale);
