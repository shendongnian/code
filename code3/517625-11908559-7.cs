    public static void WriteTextToImage(string inputFile, string outputFile, FormattedText text,
        Rect textRect, HorizontalAlignment hAlign, VerticalAlignment vAlign)
    {
        BitmapImage bitmap = new BitmapImage(new Uri(inputFile));
        DrawingVisual visual = new DrawingVisual();
        Point position = textRect.Location;
        switch (hAlign)
        {
            case HorizontalAlignment.Center:
                position.X += (textRect.Width - text.Width) / 2;
                break;
            case HorizontalAlignment.Right:
                position.X += textRect.Width - text.Width;
                break;
        }
        switch (vAlign)
        {
            case VerticalAlignment.Center:
                position.Y += (textRect.Height - text.Height) / 2;
                break;
            case VerticalAlignment.Bottom:
                position.Y += textRect.Height - text.Height;
                break;
        }
        using (DrawingContext dc = visual.RenderOpen())
        {
            dc.DrawImage(bitmap, new Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
            dc.DrawText(text, position);
        }
        RenderTargetBitmap target = new RenderTargetBitmap(bitmap.PixelWidth, bitmap.PixelHeight,
                                                           bitmap.DpiX, bitmap.DpiY, PixelFormats.Default);
        target.Render(visual);
        BitmapEncoder encoder = null;
        switch (Path.GetExtension(outputFile))
        {
            case ".png":
                encoder = new PngBitmapEncoder();
                break;
            case ".jpg":
                encoder = new JpegBitmapEncoder();
                break;
        }
        if (encoder != null)
        {
            encoder.Frames.Add(BitmapFrame.Create(target));
            using (FileStream outputStream = new FileStream(outputFile, FileMode.Create))
            {
                encoder.Save(outputStream);
            }
        }
    }
