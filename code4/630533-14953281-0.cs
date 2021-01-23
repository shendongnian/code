    public BitmapSource RenderElement(UIElement element, Size size)
    {
        element.Measure(size);
        element.Arrange(new Rect(size));
        var bitmap = new RenderTargetBitmap(
            (int)size.Width, (int)size.Height, 96, 96, PixelFormats.Default);
        bitmap.Render(element);
        return bitmap;
    }
