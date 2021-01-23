    public void SaveDrawingToFile(Drawing drawing, string fileName, double scale)
    {
        var drawingVisual = new DrawingVisual();
        using (var drawingContext = drawingVisual.RenderOpen())
        {
            drawingContext.PushTransform(new ScaleTransform(scale, scale));
            drawingContext.PushTransform(new TranslateTransform(-drawing.Bounds.X, -drawing.Bounds.Y));
            drawingContext.DrawDrawing(drawing);
        }
        var width = drawing.Bounds.Width * scale;
        var height = drawing.Bounds.Height * scale;
        var bitmap = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
        bitmap.Render(drawingVisual);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = new FileStream(fileName, FileMode.Create))
        {
            encoder.Save(stream);
        }
    }
