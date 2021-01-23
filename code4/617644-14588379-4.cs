    //calculate the new width proportionally to the new height it will have
    int newWidth =  file1.Width + file1.Width / (file2.Height / (file2.Height - file1.Height));
    Bitmap bitmap = new Bitmap(newWidth + file2.Width, Math.Max(file1.Height, file2.Height));
    using (Graphics g = Graphics.FromImage(bitmap))
    {       
         //high quality rendering and interpolation mode
         g.SmoothingMode = SmoothingMode.HighQuality; 
         g.PixelOffsetMode = PixelOffsetMode.HighQuality; 
         g.InterpolationMode = InterpolationMode.HighQualityBicubic;
         //resize the left image
         g.DrawImage( file1, new Rectangle( 0, 0, newWidth, file2.Height ) );
         g.DrawImage(file2, newWidth, 0);
    }
