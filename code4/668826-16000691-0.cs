    public static void TakeCroppedScreenShot(
        string fileName, int x, int y, int width, int height, ImageFormat format)
    {
        Rectangle r = new Rectangle(x, y, width, height);
        Bitmap bmp = new Bitmap(r.Width, r.Height, PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(bmp);
        g.CopyFromScreen(r.Left, r.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
        bmp.Save(fileName, format);
    }
