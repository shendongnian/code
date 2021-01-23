        static public void PreMultiplyAlpha(this Texture2D texture) {            
            //Setup a render target to hold our final texture which will have premulitplied color values
            var result = new RenderTarget2D(texture.GraphicsDevice, texture.Width, texture.Height);
            texture.GraphicsDevice.SetRenderTarget(result);
            texture.GraphicsDevice.Clear(Color.Black);
            // Using default blending function
            // (source × Blend.SourceAlpha) + (destination × Blend.InvSourceAlpha)
            // Destination is zero so the reduces to
            // (source × Blend.SourceAlpha)
            // So this multiplies our color values by the alpha value and draws it to the RenderTarget
            var blendColor = new BlendState {
                ColorWriteChannels = ColorWriteChannels.Red | ColorWriteChannels.Green | ColorWriteChannels.Blue,
                AlphaDestinationBlend = Blend.Zero,
                ColorDestinationBlend = Blend.Zero,
                AlphaSourceBlend = Blend.SourceAlpha,
                ColorSourceBlend = Blend.SourceAlpha
            };
            var spriteBatch = new SpriteBatch(texture.GraphicsDevice);
            spriteBatch.Begin(SpriteSortMode.Immediate, blendColor);
            spriteBatch.Draw(texture, texture.Bounds, Color.White);
            spriteBatch.End();
            // Simply copy over the alpha channel
            var blendAlpha = new BlendState {
                ColorWriteChannels = ColorWriteChannels.Alpha,
                AlphaDestinationBlend = Blend.Zero,
                ColorDestinationBlend = Blend.Zero,
                AlphaSourceBlend = Blend.One,
                ColorSourceBlend = Blend.One
            };
            spriteBatch.Begin(SpriteSortMode.Immediate, blendAlpha);
            spriteBatch.Draw(texture, texture.Bounds, Color.White);
            spriteBatch.End();
            texture.GraphicsDevice.SetRenderTarget(null);
            var t = new Color[result.Width * result.Height];
            result.GetData(t);
            texture.SetData(t);
        }
