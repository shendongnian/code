        public class Game1 : Microsoft.Xna.Framework.Game
        {
             Paddle Paddle1 = new Paddle();
             Paddle Paddle2 = new Paddle();
        ...
         protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
     
                Paddle1.LoadContent();
            }
        ...
        }
    
        class Paddle : Game1
        {
        ...
            protected override void LoadContent()
            {
                Paddle1 = new Vector2();
                Paddle1.X = 50;
                Paddle1.Y = 50;
                base.LoadContent();
            }
        ...
        }
