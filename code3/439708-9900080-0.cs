    MouseState ms = Mouse.GetState(); 
            double x = Math.Floor(((double)ms.X + (double)cameraPosition.X)/ (double)16) ;
            double y = Math.Floor(((double)ms.Y + (double)cameraPosition.Y)/ (double)16);
            try
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    tiles[(int)x, (int)y] = //Left Button Pressed, Change the Texture here!
                }
                if (ms.RightButton == ButtonState.Pressed)
                {
                    tiles[(int)x, (int)y] =  //Right Button Pressed, Change the Texture here!
 
                }
    if (ms.LeftButton == ButtonState.Pressed)
                {
                    tiles[(int)x, (int)y] = //Left Button Pressed, Change the Texture here!
                }
                if (ms.RightButton == ButtonState.Pressed)
                {
                    tiles[(int)x, (int)y] =  //Right Button Pressed, Change the Texture here!
 
                }
            }
