     if (lastSize.X != Width || lastSize.Y != Height || stripesBg.IsContentLost || stripes.IsContentLost)
                {
                    
                    Console.WriteLine("Redrawing Progressbar");
                    //redraw textures!
                    //stripesBg = new RenderTarget2D(graphicsManager.GraphicsDevice, Width, Height, false, graphicsManager.GraphicsDevice.DisplayMode.Format, DepthFormat.Depth24, 1, RenderTargetUsage.PreserveContents);
                    //stripes = new RenderTarget2D(graphicsManager.GraphicsDevice, Width, Height * 2, false, graphicsManager.GraphicsDevice.DisplayMode.Format, DepthFormat.Depth24, 1, RenderTargetUsage.PreserveContents);
                    stripesBg = new RenderTarget2D(graphicsManager.GraphicsDevice, Width, Height);
                    stripes = new RenderTarget2D(graphicsManager.GraphicsDevice, Width, Height * 2);
    [...]
