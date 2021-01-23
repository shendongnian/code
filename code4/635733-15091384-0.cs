    GraphicsDevice.SetRenderTarget(textureBuffer);
        
    spriteBatch.Begin();
    spriteBatch.Draw(textureSummer, new Vector2(0, 0), Color.White); // texture Summer is a 20x20 pixels texture while the screen resolution is 480 x 800
    spriteBatch.End();
        
    GraphicsDevice.SetRenderTarget(null); // switch back 
        
    spriteBatch.Begin();
    spriteBatch.Draw(textureBackground, new Vector2(0,0), Color.White); // This is a 480x800 image and my resolution is set to 480x800
    spriteBatch.Draw(textureBuffer, new Vector2(0,0), Color.White);
    spriteBatch.End();
