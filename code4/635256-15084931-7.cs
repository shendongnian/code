    class Label: Panel{
    
    SpriteFont Font { get; set; }
    String Text { get; set; }
    Vector2 TextOffset { get; set; }
    Color TextColor { get; set; }
    
    override Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
        spriteBatch.DrawString(Font, Text, Position + TextOffset,Text Color);
        DrawChildren(spriteBatch);
    }
    
    }
