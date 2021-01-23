    public static void CreateBitmapFromVisual(Visual target, string filename)
    {
        // target will be your Canvas
        // filename is the path where you want to save the image
        if (target == null)
            return;
        Rect bounds = VisualTreeHelper.GetDescendantBounds(target);            
        RenderTargetBitmap rtb = new RenderTargetBitmap((Int32)bounds.Width, (Int32)bounds.Height, 96, 96, PixelFormats.Default);
        rtb.Render(target);            
        JpegBitmapEncoder jpg = new JpegBitmapEncoder();
        jpg.Frames.Add(BitmapFrame.Create(rtb));
        using (Stream stm = File.Create(filename))
        {
            jpg.Save(stm);
        }
    }
