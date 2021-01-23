    private static Image resizeImage(Image imgToResize, Size size)
    {
    	Bitmap b = new Bitmap(size.Width, size.Height);
    	Graphics g = Graphics.FromImage((Image)b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
        g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        g.Dispose();
    
        return (Image)b;
    }
