    public void Update(GameTime gameTime)
    {
        keyboard = Keyboard.GetState();
        if (CheckKeyboard(Keys.Up))
        {
            if (selected > 0)
            {
                selected--;
            }
        }
        if (CheckKeyboard(Keys.Down))
        {
            if (selected < buttonList.Count - 1)
            {
                selected++;
            }
        }
        prevKeyboard = keyboard; // <=========== CHANGE MADE HERE
    }
    public bool CheckKeyboard(Keys key)
    {
        return (keyboard.IsKeyDown(key) && prevKeyboard.IsKeyUp(key));
    }
