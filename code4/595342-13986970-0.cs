    private static Image resizeImage(Image imgToResize, Size size)
    {
        int sourceWidth = imgToResize.Width;
        int sourceHeight = imgToResize.Height;
        double wRatio = (double)size.Width / sourceWidth;
        double hRatio = (double)size.Height / sourceHeight;
        int destWidth, destHeight;
        float top, left;
        if (wRatio > hRatio) // reverse for white bars rather than trimming
        {
            destWidth = size.Width;
            destHeight = (int)Math.Ceiling(sourceHeight * wRatio);
            left = 0;
            top = (destHeight - size.Height) / 2f;
        }
        else
        {
            destHeight = size.Height;
            destWidth = (int)Math.Ceiling(sourceWidth * hRatio);
            top = 0;
            left = (destWidth - size.Width) / 2f;
        }
        Bitmap b = new Bitmap(destWidth, destHeight);
        Graphics g = Graphics.FromImage((Image)b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(imgToResize, left, top, destWidth, destHeight);
        g.Dispose();
        return (Image)b;
    }
