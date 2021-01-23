    public class Game1 : Microsoft.Xna.Framework.Game
    {
        ...
        private bool _drawn = false;
        protected override void Update(GameTime gameTime)
        {
            if (_drawn)
                SuppressDraw();
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            /* draw stuff here */
            spriteBatch.End();
            _drawn = true;
        }
        ...
    }
