    public void SaveDrawingToFile(Drawing drawing, string fileName, double scale)
    {
        var drawingImage = new Image { Source = new DrawingImage(drawing) };
        var width = drawing.Bounds.Width * scale;
        var height = drawing.Bounds.Height * scale;
        drawingImage.Arrange(new Rect(0, 0, width, height));
        var bitmap = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
        bitmap.Render(drawingImage);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = new FileStream(fileName, FileMode.Create))
        {
            encoder.Save(stream);
        }
    }
