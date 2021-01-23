     public class Sprite
        {
            public Vector2 Location;
            public Texture2D Texture;
    
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Texture, Location, Color.White);
            }
        }
    
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
    
            List<Sprite> sprites;
    
            Sprite mario, cloud;
    
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
    
            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
    
                // Create the sprites.            
                sprites = new List<Sprite>();
                mario = new Sprite() { Location = new Vector2(100, 100), Texture = Content.Load<Texture2D>("MarioTexture") };
                cloud = new Sprite() { Location = new Vector2(200, 200), Texture = Content.Load<Texture2D>("CloudTexture") };
                sprites.Add(mario);
                sprites.Add(cloud);
            }
    
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
    
                spriteBatch.Begin();
                foreach (var sprite in sprites)
                    sprite.Draw(spriteBatch);
                spriteBatch.End();
    
                base.Draw(gameTime);
            }
        }
