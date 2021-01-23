        KeyboardState keyboard;
        KeyboardState prevKeyboard;
        MouseState mouse;
        MouseState prevMouse;
        GraphicsDevice graphicsDevice;
        Texture2D mTheQuantumBros2;
        SpriteFont spriteFont;
        List<string> buttonList = new List<string>();
        int selected = 0;
        int screenWidth;
        int screenHeight;
        public MenuComponent()
        {
            buttonList.Add("Campaign");
            buttonList.Add("Multiplayer");
            buttonList.Add("Zombies");
            buttonList.Add("Quit Game");
        }
        public void LoadContent(ContentManager Content, int _screenWidth, int _screenHeight)
        {
            spriteFont = Content.Load<SpriteFont>("Font");
            mTheQuantumBros2 = Content.Load<Texture2D>("TheQuantumBros2");
            screenHeight = _screenHeight;
            screenWidth = _screenWidth;
        }
        
        public void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            if (CheckKeyboard(Keys.Up))
            {
                if (selected > 0) selected--;
            }
            if (CheckKeyboard(Keys.Down))
            {
                if (selected < buttonList.Count - 1) selected++;
            }
            prevMouse = mouse;
            prevKeyboard = keyboard;
        }
        public bool CheckMouse()
        {
            return (mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released);
        }
        public bool CheckKeyboard(Keys key)
        {
            return (keyboard.IsKeyDown(key) && prevKeyboard.IsKeyDown(key));
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Color color;
            int linePadding = 3;
            if (gameTime.TotalGameTime.TotalSeconds <= 3)
            {
                spriteBatch.Draw(mTheQuantumBros2, new Rectangle(300, 150, mTheQuantumBros2.Width, mTheQuantumBros2.Height), Color.White);
            }
            else
            {
                for (int i = 0; i < buttonList.Count; i++)
                {
                    color = (i == selected) ? Color.LawnGreen : Color.Gold;
                    spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2((screenWidth / 2) - (spriteFont.MeasureString(buttonList[i]).X / 2), (screenHeight / 2) - (spriteFont.LineSpacing * (buttonList.Count) / 2) + ((spriteFont.LineSpacing + linePadding) * i)), color);
                }
            }
        }
