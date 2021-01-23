    ResolveTexture2D backBufferData;
    
    backBufferData = new ResolveTexture2D(
        graphics.GraphicsDevice,
        graphics.GraphicsDevice.PresentationParameters.BackBufferWidth,
        graphics.GraphicsDevice.PresentationParameters.BackBufferHeight,
        1,
        graphics.GraphicsDevice.PresentationParameters.BackBufferFormat
    );
    
    Rectangle sourceRectangle = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
    
    Color[] retrievedColor = new Color[1];
    graphics.GraphicsDevice.ResolveBackBuffer(backBufferData);
    backBufferData.GetData<Color>(
        0,
        sourceRectangle,
        retrievedColor,
        0,
    1);
    selectedColor = retrievedColor[0];
