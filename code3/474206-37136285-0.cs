    // Create a render bitmap and push the surface to it
    RenderTargetBitmap renderBitmap =
        new RenderTargetBitmap(
        (int)size.Width,
        (int)size.Height,
        96d,
        96d,
        PixelFormats.Pbgra32
    );
    
    // Render a white background into buffer for clipboard to avoid black background on some elements
	Rectangle vRect = new Rectangle()
	{
		Width = (int)size.Width,
		Height = (int)size.Height,
		Fill = Brushes.White,
	};
	vRect.Arrange(new Rect(size));
	renderBitmap.Render(vRect);
    // renderBitmap is now white, so render your object on it
    renderBitmap.Render(surface);
    
    // Copy it to clipboard
    try
    {
        Clipboard.SetImage(resultBitmap);
    } catch { ... }
