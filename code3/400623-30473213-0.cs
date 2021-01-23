    public Texture2D CreateBlurredTexture(Texture2D originalTexture, SpriteEffects effects)
        {
            var device = originalTexture.GraphicsDevice;
            var rt = new RenderTarget2D(device, originalTexture.Width/2, originalTexture.Height/2);
            var rt2 = new RenderTarget2D(device, originalTexture.Width, originalTexture.Height);
            Color shadowColor = Color.Lerp(Color.Black, Color.Transparent, 0.9f);
            using (var spriteBatch = new SpriteBatch(device))
            {
                device.SetRenderTarget(rt);
                device.Clear(Color.Transparent);
                spriteBatch.Begin();
                spriteBatch.Draw(originalTexture, new Rectangle(0, 0, rt.Width, rt.Height), null, shadowColor, 0, Vector2.Zero, effects, 0f);
                spriteBatch.Draw(originalTexture, new Rectangle(1, 1, rt.Width - 2, rt.Height - 2), null, shadowColor, 0, Vector2.Zero, effects, 0f);
                spriteBatch.Draw(originalTexture, new Rectangle(2, 2, rt.Width - 4, rt.Height - 4), null, shadowColor, 0, Vector2.Zero, effects, 0f);
                spriteBatch.Draw(originalTexture, new Rectangle(3, 3, rt.Width - 6, rt.Height - 6), null, shadowColor, 0, Vector2.Zero, effects, 0f);
                spriteBatch.Draw(originalTexture, new Rectangle(4, 4, rt.Width - 8, rt.Height - 8), null, shadowColor, 0, Vector2.Zero, effects, 0f);
                spriteBatch.End();
                device.SetRenderTarget(rt2);
                device.Clear(Color.Transparent);
                spriteBatch.Begin();
                spriteBatch.Draw(rt, new Rectangle(0, 0, rt2.Width, rt2.Height), Color.White);
                spriteBatch.End();
                device.SetRenderTarget(null);
            }
            return rt2;
        }
