        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);
            spriteBatch.Draw(texture, new Vector2(resolution.Width / 2, resolution.Height / 2), null, Color.White, 0, Vector2.Zero, 0.25f, SpriteEffects.FlipVertically, 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
