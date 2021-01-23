     public Level(String back ,ContentManager content, EventHandler ScreenEvent, Microsoft.Xna.Framework.Game game) : base(ScreenEvent)
    {
        background = back;
        backgroundVector = new Vector2(-1150, 0);
        velocity = 5.0f;
        ground = 508;
        graphics = new GraphicsDeviceManager(game);   
    }
