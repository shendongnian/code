        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);
            spriteBatch.Draw(texture, Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipVertically, 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
