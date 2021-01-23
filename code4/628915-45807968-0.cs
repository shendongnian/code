    System.Drawing.Bitmap bm = null;
    //RotateTransform(angle) with RenderTransformOrigin="0.5,0.5" might cause blurry if the width or height is odd,
    using (System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(path))
    {
        int width = bitmap.Width;
        int height = bitmap.Height;
        if (0 != width % 2) width ++;
        if (0 != height % 2) height ++;
        bm = new System.Drawing.Bitmap(width, height);
                    
        bm.SetResolution(96, 96);
        using (System.Drawing.Graphics g = System.Drawing. Graphics.FromImage(bm))
        {
            //I don't want to do anything which may modify(resize) the original image.
            g.Clear(System.Drawing.Color.White);
            g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
        }
        //bm.Save(directory+@"\tmp.bmp", ImageFormat.Bmp);
                    
    }
    //.....(show bm)
