    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // ...
        protected override void Update(GameTime gameTime)
        {            
            if (kbState.IsKeyDown(Keys.Escape))
                Exit();  
      
            base.Update(gameTime);
        }
        // ...
    }
