    RenderTarget2D target = new RenderTarger2D(...); 
    //I cant remeber the arguments off the top of my head.
    //I think its GraphicsDevice, Width, Height, GenerateMipmap, SurfaceFormat, Depthformat
    
    GraphicsDevice.SetRenderTarget(target);
    GraphicsDevice.Clear(Color.Black); //any colour will do
    using(SpriteBatch b = new SpriteBatch(GraphicsDevice))
    {
       b.Begin();
    
       //Loop through all texture and draw them, so ...
       for(int y = 0; y < 10; i++)
         for(int y = 0; y < 10; i++)
           batch.Draw(Texture, new Rectangle(xPos, yPos, width, height), Color.White));
    
       b.End();
    }
    GraphicsDevice.SetRenderTarget(null);
    //Then to access your new Texture, just do 
    Texture newTexture = target; //Target inherits from Texture2D so no casting needed
