    for (int i = 0; i < paginator.PageCount; i++)
    {
        DocumentPage page = paginator.GetPage(i);
        double width = page.Size.Width;
        double height = page.Size.Height;
        double maxWidth = Math.Round(21.0 / 2.54 * 96.0); // A4 width in pixels at 96 dpi
        double maxHeight = Math.Round(29.7 / 2.54 * 96.0); // A4 height in pixels at 96 dpi
        double scale = 1.0;
        scale = Math.Min(scale, maxWidth / width);
        scale = Math.Min(scale, maxHeight / height);
        ContainerVisual containerVisual = new ContainerVisual();
        containerVisual.Transform = new ScaleTransform(scale, scale);
        containerVisual.Children.Add(page.Visual);
        RenderTargetBitmap bitmap = new RenderTargetBitmap(
            (int)(width * scale), (int)(height * scale), 96, 96, PixelFormats.Default);
        bitmap.Render(containerVisual);
        ...
    }
