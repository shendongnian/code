    class Block 
    {
        public virtual void Draw(SomeObj spriteBatch, Vector2 vector) { }
    }
    
    class Wall : Block
    {
        public override void Draw(SomeObj spriteBatch, Vector2 vector) { }
    }
