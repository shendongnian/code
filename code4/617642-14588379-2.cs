    using (Graphics g = Graphics.FromImage(bitmap))
    {       
         //high quality rendering and interpolation mode
         g.SmoothingMode = SmoothingMode.HighQuality; 
         g.PixelOffsetMode = PixelOffsetMode.HighQuality; 
         g.InterpolationMode = InterpolationMode.HighQualityBicubic;
         //resize the left image
         g.DrawImage(file1, new Rectangle(0, 0, file1.Width, file2.Height));
         g.DrawImage(file2, file1.Width, 0);
    }
