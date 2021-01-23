    public static void SaveAsImage(
        FrameworkElement element, 
        string filepath, 
        int width, 
        int height)
    {
        element.Width = width;
        element.Height = height;
        element.Measure(new Size(width, height));
        element.Arrange(new Rect(0, 0, width, height));
        element.UpdateLayout();
        var target = new RenderTargetBitmap(
            width, height,
            96, 96, System.Windows.Media.PixelFormats.Pbgra32);
        target.Render(element);
        var encoder = new PngBitmapEncoder();
        var outputFrame = BitmapFrame.Create(target);
        encoder.Frames.Add(outputFrame);
        using (var file = File.OpenWrite(filepath))
        {
            encoder.Save(file);
        }
    }
