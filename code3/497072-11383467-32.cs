    class Asteroid
    {
        public void Update(float elapsedSeconds)
        {
            position.Y += asteroidSpeed * elapsedSeconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(asteroidTexture, position, Color.White);
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        protected override void Update(GameTime gameTime)
        {
            foreach(Asteroid asteroid in asteroids)
            {
                asteroid.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            foreach(Asteroid asteroid in asteroids)
            {
                asteroid.Draw(spriteBatch);
            }
        }
    }
