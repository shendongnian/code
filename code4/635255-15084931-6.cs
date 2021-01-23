    class Panel: UIControl {
    
    Vector2 Position { get; set; }
    Texture2D Texture { get; set; }
    
    override Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
        base.Draw(spriteBatch);
    }
    
    }
