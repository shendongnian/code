    public class Sprite
    {
        static Vector2 WorldOrigo = new Vector2(400, 240); //center of a 800x480 screen
        
        Texture2D Texture { get; set; }
        Vector2 Origin { get; set; }
    
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }
    
        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, WorldOrigo + position - Origin, Color.White);
        }
    }
