            effect.Projection = projections[0];
            GraphicsDevice.SetRenderTarget(renderTargets[0]);
            GraphicsDevice.Clear(Color.Transparent);
            // render scene here
            effect.Projection = projections[1];
            GraphicsDevice.SetRenderTarget(renderTargets[1]);
            GraphicsDevice.Clear(Color.Transparent);
            // render scene here
            effect.Projection = projections[2];
            GraphicsDevice.SetRenderTarget(renderTargets[2]);
            GraphicsDevice.Clear(Color.Transparent);
            // render scene here
            GraphicsDevice.SetRenderTarget(null);
