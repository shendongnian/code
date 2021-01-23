    RenderTarget2D unprocessed = new RenderTarget2D( /*...*/);
    graphics.GraphicsDevice.SetRenderTarget(unprocessed);
    graphics.GraphicsDevice.Clear(Color.Black);
    //Drawing
    spriteBatch.Begin();
    spriteBatch.Draw(/*...*/);
    spriteBatch.End();
    //Getting
    graphics.GraphicsDevice.SetRenderTarget(null);
    
