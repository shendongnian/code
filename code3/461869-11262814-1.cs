    private Texture2D SpriteTexture;
    private Rectangle TitleSafe;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteTexture = Content.Load<Texture2D>("ship");
            TitleSafe = GetTitleSafeArea(.8f);
        }
        protected Rectangle GetTitleSafeArea(float percent)
        {
            Rectangle retval = new Rectangle(
                graphics.GraphicsDevice.Viewport.X,
                graphics.GraphicsDevice.Viewport.Y,
                graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height);
            return retval;
        }
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            Vector2 pos = new Vector2(TitleSafe.Left, TitleSafe.Top);
            spriteBatch.Draw(SpriteTexture, pos, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
