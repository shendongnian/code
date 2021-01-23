      public class Sprite
        {
            public Vector2 Location;
            public Texture2D Texture;
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Texture, Location, Color.White);
            }
        }
