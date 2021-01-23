        GraphicsDevice.SetRenderTarget(renderTarget);
        GraphicsDevice.Clear(Color.Transparent);
        // Draw stuff to texture
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(BackgroundColor);  // Important to clear here
        // Draw background
        // Draw texture
        // Draw stuff
         
