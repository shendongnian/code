        spriteBatch.Begin(
            SpriteSortMode.Deferred, 
            BlendState.AlphaBlend, 
            SamplerState.AnisotropicClamp, 
            null, null);
        spriteBatch.Draw(renderTargets[0], GraphicsDevice.Viewport.Bounds, Color.White);
        spriteBatch.Draw(renderTargets[1], GraphicsDevice.Viewport.Bounds, Color.White);
        spriteBatch.Draw(renderTargets[2], GraphicsDevice.Viewport.Bounds, Color.White);
        spriteBatch.End();
