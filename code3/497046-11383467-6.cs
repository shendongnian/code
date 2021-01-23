    public class Game1 : Microsoft.Xna.Framework.Game
    {
        protected override void Update(GameTime gameTime)
        {
            // ... other stuff ...
            int screenHeight = GraphicsDevice.Viewport.Height;
            // Loop backwards through all asteroids.
            //
            // Note that you must iterate backwards when removing items from a list 
            // by index, as removing an item will change the indices of all items in
            // the list following (in a forward order) the item that you remove.
            for(int i = asteroids.Count - 1; i >= 0; i--)
            {
                if(asteroids[i].Position.Y > screenHeight)
                    asteroids.RemoveAt(i);
            }
        }
    }
