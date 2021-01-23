        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            var largeRect = new Rectangle(50, 50, sprite.Width * 3, sprite.Height * 3);
            /// start the batch, but in immediate mode to avoid antialiasing
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            /// set the filter to Point
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            
            /// draw the sprite
            spriteBatch.Draw(sprite, largeRect, Color.White);
            /// done!
            spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
