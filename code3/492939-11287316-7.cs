    public class Game1 : Microsoft.Xna.Framework.Game
    {
        protected override void Update(GameTime gameTime)
        {
            if(userClickedTheResolutionChangeButton)
            {
                graphics.IsFullScreen = userRequestedFullScreen;
                graphics.PreferredBackBufferHeight = userRequestedHeight;
                graphics.PreferredBackBufferWidth = userRequestedWidth;
                graphics.ApplyChanges();
            }
            // ...
        }
        // ...
    }
