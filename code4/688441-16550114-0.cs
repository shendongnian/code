        public void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            if (CheckKeyboard(Keys.Up))
            {
                if (selected > 0) selected--;
                else{selected = buttonList.Count - 1;}
            }
            if (CheckKeyboard(Keys.Down))
            {
                if (selected < buttonList.Count - 1) selected++;
                else {selected = 0;}
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
            //Here is the only thing that needed to be changed, based on your original post
            //you were checking if both keys were down originally, meaning it was always 
            // true while a button was pressed. if the previous keyboard was down,
            //and the current keyboard is up, it means the button was released.
            return (keyboard.IsKeyUp(key) && prevKeyboard.IsKeyDown(key));
        }
