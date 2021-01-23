    public void Draw (
         Texture2D texture,
         Vector2 position,
         Nullable<Rectangle> sourceRectangle,
         Color color,
         float rotation,
         Vector2 origin,
         Vector2 scale,
         SpriteEffects effects,
         float layerDepth)
    //Using:
    var origin = new Vector2()
    {
        X = texture.Width / 2,
        Y = texture.Height/ 2
    };
    
    spriteBatch.Draw(texture, Vector2.Zero, null, Color.White, MathHelper.Pi, origin, 1f, SpriteEffects.None, 0f)`
