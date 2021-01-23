      void Screenie()
                {
                    int width = GraphicsDevice.PresentationParameters.BackBufferWidth;
                    int height = GraphicsDevice.PresentationParameters.BackBufferHeight;
    
                    //Force a frame to be drawn (otherwise back buffer is empty) 
                    Draw(new GameTime());
    
                    //Pull the picture from the buffer 
                    int[] backBuffer = new int[width * height];
                    GraphicsDevice.GetBackBufferData(backBuffer);
    
                    //Copy to texture
                    Texture2D texture = new Texture2D(GraphicsDevice, width, height, false, GraphicsDevice.PresentationParameters.BackBufferFormat);
                    texture.SetData(backBuffer);
                    //Get a date for file name
                    DateTime date = DateTime.Now; //Get the date for the file name
                    Stream stream = File.Create(SCREENSHOT FOLDER + date.ToString("MM-dd-yy H;mm;ss") + ".png"); 
    
                    //Save as PNG
                    texture.SaveAsPng(stream, width, height);
                    stream.Dispose();
                    texture.Dispose();
                }
