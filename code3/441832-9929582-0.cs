            _renderTarget = new RenderTarget2D(
                GraphicsDevice, 
                (int)size.X, 
                (int)size.Y);
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Transparent);
            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            //draw some stuff.
            SpriteBatch.End()
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Blue);
            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            SpriteBatch.Draw(_renderTarget, Vector2.Zero, Color.white);
            SpriteBatch.End()
