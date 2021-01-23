    // Begin drawing with the default states
    // Except the SamplerState should be set to PointWrap, LinearWrap or AnisotropicWrap
    spriteBatch.Begin(
        SpriteSortMode.Deferred, 
        BlendState.Opaque, 
        SamplerState.AnisotropicWrap, // Make the texture wrap
        DepthStencilState.Default, 
        RasterizerState.CullCounterClockwise
    );
    // Rectangle over the whole game screen
    var screenArea = new Rectangle(0, 0, 800, 600);
    // Calculate the current offset of the texture
    // For this example I use the game time
    var delta = gameTime.TotalGameTime.TotalMilliseconds;
    int offset = (int)(delta);
    // Offset increases over time, so the texture moves from the bottom to the top of the screen
    var destination =  new Rectangle(0, offset, texture.Width, texture.Height);
    // Draw the texture 
    spriteBatch.Draw(
        texture, 
        screenArea, 
        destination,
        Color.White
    );
