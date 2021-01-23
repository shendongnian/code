    var pp = GraphicsDevice.PresentationParameters;
    renderTargets = new List<RenderTarget2D>()
    {
        new RenderTarget2D(GraphicsDevice,
                GraphicsDevice.Viewport.Width / 8,
            GraphicsDevice.Viewport.Height / 8,
            false, pp.BackBufferFormat, pp.DepthStencilFormat),
            new RenderTarget2D(GraphicsDevice,
            GraphicsDevice.Viewport.Width / 4,
            GraphicsDevice.Viewport.Height / 4,
            false, pp.BackBufferFormat, pp.DepthStencilFormat),
        new RenderTarget2D(GraphicsDevice,
            GraphicsDevice.Viewport.Width,
            GraphicsDevice.Viewport.Height,
            false, pp.BackBufferFormat, pp.DepthStencilFormat),
    };
