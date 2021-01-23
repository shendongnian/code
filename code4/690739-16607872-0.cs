    public class Game1 : Game
    {
        Level level;
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            level = new Level();
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            level.Update(gameTime);
            base.Update(gameTime);
        }
