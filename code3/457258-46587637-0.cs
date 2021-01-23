       private static BitmapFrame CreateResizedImage(ImageSource source, int Max_width, int Max_height, int margin)
    {
        float scaleHeight = (float)Max_width / (float)source.Height;
        float scaleWidth = (float)Max_height / (float)source.Width;
        float scale = Math.Min(scaleHeight, scaleWidth);
         int width = (int)(source.Width * scale);
         int height = (int)(source.Height * scale);
        var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);
        var group = new DrawingGroup();
        RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
        group.Children.Add(new ImageDrawing(source, rect));
        var drawingVisual = new DrawingVisual();
        using (var drawingContext = drawingVisual.RenderOpen())
            drawingContext.DrawDrawing(group);
        var resizedImage = new RenderTargetBitmap(
            width, height,         // Resized dimensions
            96, 96,                // Default DPI values
            PixelFormats.Default); // Default pixel format
        resizedImage.Render(drawingVisual);
        return BitmapFrame.Create(resizedImage);
    }
    //--------Main------------//
      BitmapImage imageSource = (BitmapImage)ImagePreview.Source;
      var NewImage= CreateResizedImage(imageSource , 300, 300, 0);
