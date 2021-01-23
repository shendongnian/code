    Size size = new Size(surface.Width, surface.Height);
    surface.Measure(size);
    surface.Arrange(new Rect(size));
    // Create a render bitmap and push the surface to it
    RenderTargetBitmap renderBitmap =
        new RenderTargetBitmap((int)size.Width, (int)size.Height, 96d, 96d,
                               PixelFormats.Pbgra32);
    DrawingVisual drawingVisual = new DrawingVisual();
    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
    {
        VisualBrush visualBrush = new VisualBrush(surface);
        drawingContext.DrawRectangle(visualBrush, null, 
          new Rect(new Point(), new Size(size.Width, size.Height)));
    }
    renderBitmap.Render(drawingVisual);
    
    // Create a file stream for saving image
    using (FileStream outStream = new FileStream(filename, FileMode.Create))
    {
        BmpBitmapEncoder encoder = new BmpBitmapEncoder();
        // push the rendered bitmap to it
        encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
        // save the data to the stream
        encoder.Save(outStream);
    }
