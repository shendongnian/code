    Viewbox viewbox = new Viewbox();
    Size desiredSize = new Size(surface.Width / 2, surface.Height / 2);
    viewbox.Child = surface;
    viewbox.Measure(desiredSize);
    viewbox.Arrange(new Rect(desiredSize));
    RenderTargetBitmap renderBitmap =
        new RenderTargetBitmap(
        (int)desiredSize.Width,
        (int)desiredSize.Height, 96d, 96d,
        PixelFormats.Default);
    renderBitmap.Render(viewbox);
