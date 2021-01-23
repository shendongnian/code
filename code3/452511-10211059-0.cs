    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        protected override void Initialize()
        {
                graphics = new GraphicsDeviceManager(this);  
                base.Initialize();
        }
    }
