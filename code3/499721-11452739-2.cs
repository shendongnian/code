    public static void ExportToImage(Canvas canvas, System.Drawing.Bitmap bmp)
    {
        // Save old background
        Brush background = canvas.Background;
        // Clear background to make images free of it
        canvas.Background = null;
    
    
        // Create a render bitmap and push the surface to it
        RenderTargetBitmap renderBitmap =
            new RenderTargetBitmap(
                (int)canvas.Width,
                (int)canvas.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
        renderBitmap.Render(canvas);
    
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, 
        new Action(delegate() 
        {
            MemoryStream picStream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            encoder.Save(picStream);
    
            canvas.Background = background;
    
            // I don't think you can simply return your value here, 
            // so you'll probably need to setup something else to 
            // return your bitmap to your calling code
            bmp = new System.Drawing.Bitmap(picStream);
        }));
    }
