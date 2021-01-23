    public class Game1 : Microsoft.Xna.Framework.Game
    {
        List<Asteroid> asteroids = new List<Asteroid>();
        protected override void Initialize()
        {
            int screenWidth = GraphicsDevice.Viewport.Width;
            // Create 15 asteroids:
            for(int i = 0; i < 15; i++)
            {
                float xPosition = Shared.Random.Next(0, screenWidth);
                asteroids.Add(new Asteroid(new Vector2(xPosition, 0));
            }
        }
    }
