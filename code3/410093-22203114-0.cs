    const int TargetSize = 14;
    
    private static void Save(Geometry geometry, string fileName)
    {
        var rect = geometry.GetRenderBounds(new Pen(Brushes.Black, 0));
    
        var bigger = rect.Width > rect.Height ? rect.Width : rect.Height;
        var scale = TargetSize / bigger;
    
        Geometry scaledGeometry = Geometry.Combine(geometry, geometry, GeometryCombineMode.Intersect, new ScaleTransform(scale, scale));
        rect = scaledGeometry.GetRenderBounds(new Pen(Brushes.Black, 0));
    
        Geometry transformedGeometry = Geometry.Combine(scaledGeometry, scaledGeometry, GeometryCombineMode.Intersect, new TranslateTransform(((TargetSize - rect.Width) / 2) - rect.Left, ((TargetSize - rect.Height) / 2) - rect.Top));
    
        RenderTargetBitmap bmp = new RenderTargetBitmap(TargetSize, TargetSize, // Size
                                                        96, 96, // DPI 
                                                        PixelFormats.Pbgra32);
    
        DrawingVisual viz = new DrawingVisual();
        using (DrawingContext dc = viz.RenderOpen())
        {
            dc.DrawGeometry(Brushes.Black, null, transformedGeometry);
        }
    
        bmp.Render(viz);
    
        PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
        pngEncoder.Frames.Add(BitmapFrame.Create(bmp));
    
        using (FileStream file = new FileStream(fileName, FileMode.Create))
            pngEncoder.Save(file);
    }
