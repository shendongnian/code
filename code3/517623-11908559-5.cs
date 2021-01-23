    public static void WriteTextToImage(string inputFile, string outputFile, FormattedText text, Point position)
    {
        BitmapImage bitmap = new BitmapImage(new Uri(inputFile)); // inputFile must be absolute path
        DrawingVisual visual = new DrawingVisual();
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
            // more encoders here
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
