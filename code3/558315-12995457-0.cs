    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GameTime gt;
        /* ... */    
        protected override void Update(GameTime gameTime)
        {
            gt = gameTime;
        // the rest of the Update method
        }
    }
