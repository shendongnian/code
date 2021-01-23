        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);
            spriteBatch.Draw(texture, Position, null, Color.White, (float)Math.PI, new Vector2(texture.Width, texture.Height), 1, SpriteEffects.None, 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
