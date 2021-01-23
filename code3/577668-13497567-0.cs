    class Enemy
    {       
       protected float Scale { get; set; }
       protected Texture2D Texture { get; set; }
       protected Vector2 Position { get; set; }
       
       public Enemy()
       { 
           Scale = 1f;
       }
    
       public void Hit()   
       {
           Scale = 2f;
       }
    
       public void Draw(SpriteBatch spriteBatch)
       {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 1);   
       }
    }
 
