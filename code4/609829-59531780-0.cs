    public static BitmapSource ToBitmapSource(DrawingImage source)
    {
        DrawingVisual drawingVisual = new DrawingVisual();
        DrawingContext drawingContext = drawingVisual.RenderOpen();
        drawingContext.DrawImage(source, new Rect(new Point(0, 0), new Size(source.Width, source.Height)));
        drawingContext.Close();
        RenderTargetBitmap bmp = new RenderTargetBitmap((int)source.Width, (int)source.Height, 96, 96, PixelFormats.Pbgra32);
        bmp.Render(drawingVisual);
        return bmp;
    }
