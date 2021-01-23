    class Asteroid
    {
        // Static methods can only act on static data
        public static void LoadContent(ContentManager content)
        {
            asteroidTexture = content.Load<Texture2D>("asteroid");
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        protected override void LoadContent()
        {
            Asteroid.LoadContent(Content);
        }
    }
