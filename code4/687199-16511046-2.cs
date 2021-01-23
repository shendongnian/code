        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MenuComponent menuComponent;
        public static Rectangle screen;
        public static string GameState = "Menu";
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferMultiSampling = false;
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menuComponent = new MenuComponent();
            menuComponent.LoadContent(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
        }
        protected override void UnloadContent()
        {
        }
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            switch (GameState)
            {
                case "Menu":
                    menuComponent.Update(gameTime);
                break;
            }
            base.Update(gameTime);
        }
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch (GameState)
            {
                case "Menu":
                    menuComponent.Draw(spriteBatch, gameTime);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
            
        }
