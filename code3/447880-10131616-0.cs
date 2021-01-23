        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);
            spriteBatch.Draw(texture, new Vector2(resolution.Width / 2, resolution.Height / 2), null, Color.White, (float)Math.PI, new Vector2(texture.Width, texture.Height), 1f, SpriteEffects.None, 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
