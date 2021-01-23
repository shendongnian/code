    Bitmap newBitmap = new Bitmap(destWidth, destHeight);
    Graphics g = Graphics.FromImage((Image)newBitmap);
    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    g.DrawImage(sourceImage, 0, 0, destWidth, destHeight);
    g.Dispose();
