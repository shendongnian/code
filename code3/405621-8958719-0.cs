    public void Update(GameTime gameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.Left))
        {
            xPos -= 3;
        }
        if (keyboard.IsKeyDown(Keys.Right))
        {
            xPos += 3;
        }
        rectangle.X = xPos;
    }
