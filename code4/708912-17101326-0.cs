    public namespace MyGame
    {
      public class MainGame:Game
      {
        SpriteBatch spriteBatch;
        protected override void Initialize()
        {
          spriteBatch = new SpriteBatch(GraphicsDevice);
          Services.AddService(typeof(SpriteBatch), spriteBatch);
          base.Initialize();
        }
      }
      public class DrawableComponent : DrawableGameComponent
      {
        SpriteBatch spriteBatch;
        public override void Initialize()
        {
          spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
          if(spriteBatch == null)
          { throw new Exception("No SpriteBatch found in services"); }
        }
      }
    }
