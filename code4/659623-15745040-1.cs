    protected override void LoadContent()
    {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            splashScreen = new SplashScreen(this);
            splashScreen.LoadContent(Content);
            playState = new Playing(this);
            playState.LoadContent(Content);
    }
