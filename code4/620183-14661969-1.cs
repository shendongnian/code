    // Loads the images to tile (no need to specify PngBitmapDecoder, the correct decoder is automatically selected)
    BitmapFrame frame1 = BitmapDecoder.Create(new Uri(path1), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
    BitmapFrame frame2 = BitmapDecoder.Create(new Uri(path2), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
    BitmapFrame frame3 = BitmapDecoder.Create(new Uri(path3), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
    BitmapFrame frame4 = BitmapDecoder.Create(new Uri(path4), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
    // Gets the size of the images (I assume each image has the same size)
    int imageWidth = frame1.PixelWidth;
    int imageHeight = frame1.PixelHeight;
    // Draws the images into a DrawingVisual component
    DrawingVisual drawingVisual = new DrawingVisual();
    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
    {
        drawingContext.DrawImage(frame1, new Rect(0, 0, imageWidth, imageHeight));
        drawingContext.DrawImage(frame2, new Rect(imageWidth, 0, imageWidth, imageHeight));
        drawingContext.DrawImage(frame3, new Rect(0, imageHeight, imageWidth, imageHeight));
        drawingContext.DrawImage(frame4, new Rect(imageWidth, imageHeight, imageWidth, imageHeight));
    }
    // Converts the Visual (DrawingVisual) into a BitmapSource
    RenderTargetBitmap bmp = new RenderTargetBitmap(imageWidth * 2, imageHeight * 2, 96, 96, PixelFormats.Pbgra32);
    bmp.Render(drawingVisual);
    // Creates a PngBitmapEncoder and adds the BitmapSource to the frames of the encoder
    PngBitmapEncoder encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(bmp));
    // Saves the image into a file using the encoder
    using (Stream stream = File.OpenWrite(pathTileImage))
        encoder.Save(stream);
