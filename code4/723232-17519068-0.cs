    spriteBatch.Begin(SpriteSortMode.Immediate,BlendState.Opaque);
    RasterizerState state = new RasterizerState();
    state.FillMode = FillMode.WireFrame;
    spriteBatch.GraphicsDevice.RasterizerState = state;
    
    //loop this for all sprites!
    spriteBatch.Draw(sprite, position, Color.White);
    
    spriteBatch.End();
