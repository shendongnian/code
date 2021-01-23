    public class Game1 : Microsoft.Xna.Framework.Game
    {
        protected override void Update(GameTime gameTime)
        {
            if(resolutionChanged)
            {
                graphics.PreferredBackBufferHeight = userRequestedHeight;
                graphics.PreferredBackBufferWidth = userRequestedWidth;
                graphics.ApplyChanges();
            }
    
            // ...
        }
    
        // ...
    }
