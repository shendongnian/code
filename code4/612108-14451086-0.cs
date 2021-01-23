    public class Game1 : Game
    {
        Configs configs; 
    
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
    
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
    
        protected override void Initialize()
        {
            // Pass THIS game instance to the Configs class constructor.
            configs = new Configs(this);
            base.Initialize();
        }
    
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }
    
        protected override void UnloadContent()
        {
        }
    
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
