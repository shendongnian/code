    public class Game1 : Microsoft.Xna.Framework.Game
    {
        float asteroidSpawnTimer;
        const float asteroidSpawnDelay = 5; // seconds
        void CreateAsteroid()
        {
            // This is the same code as I used in Initialize().
            // Duplicate code is extremely bad practice. So you should now modify 
            // Initialize() so that it calls this method instead.
            int screenWidth = GraphicsDevice.Viewport.Width;
            float xPosition = Shared.Random.Next(0, screenWidth);
            asteroids.Add(new Asteroid(new Vector2(xPosition, 0)));
        }
        protected override void Update(GameTime gameTime)
        {
            // ... other stuff ...
            asteroidSpawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(asteroidSpawnTimer >= asteroidSpawnDelay)
            {
                asteroidSpawnTimer -= asteroidSpawnDelay; // subtract "used" time
                CreateAsteroid();
            }
        }
    }
