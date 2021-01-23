     MouseState ms = Mouse.GetState();
        double x = Math.Floor(((double)ms.X  / (double)TILE WIDTH);
        double y = Math.Floor(((double)ms.Y  / (double)TILE HEIGHT);
            if (ms.RightButton == ButtonState.Pressed)
            {
                //Player.Position = new Vector2(x,y)... or something like that
            }
            if (ms.LeftButton == ButtonState.Pressed)
            {
                //And so on...
            }
