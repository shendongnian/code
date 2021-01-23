        public static Texture2D CreateBlurredTexture(Texture2D originalTexture, SpriteEffects effects)
        {
            var device = originalTexture.GraphicsDevice;
            var rt4 = new RenderTarget2D(device, originalTexture.Width / 4, originalTexture.Height / 4);
            using (var rt2 = new RenderTarget2D(device, originalTexture.Width * 3 / 2, originalTexture.Height * 3 / 2))
            using (var rt3 = new RenderTarget2D(device, originalTexture.Width / 2, originalTexture.Height / 2))
            using (var spriteBatch = new SpriteBatch(device))
            {
                device.SetRenderTarget(rt2);
                device.Clear(Color.Transparent);
                spriteBatch.Begin();
                spriteBatch.Draw(originalTexture, new Rectangle(0, 0, rt2.Width, rt2.Height), null, Color.White, 0, Vector2.Zero, effects, 0f);
                spriteBatch.End();
                device.SetRenderTarget(rt3);
                device.Clear(Color.Transparent);
                spriteBatch.Begin();
                spriteBatch.Draw(rt2, new Rectangle(0, 0, rt3.Width, rt3.Height), Color.White);
                spriteBatch.End();
                device.SetRenderTarget(rt4);
                device.Clear(Color.Transparent);
                spriteBatch.Begin();
                spriteBatch.Draw(rt3, new Rectangle(0, 0, rt4.Width, rt4.Height), Color.White);
                spriteBatch.End();
                device.SetRenderTarget(null);
            }
            return rt4;
        }
