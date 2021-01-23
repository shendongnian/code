    public Image GetScreenshot()
    {
        int screenWidth = Convert.ToInt32(System.Windows.SystemParameters.VirtualScreenWidth);
        int screenHeight = Convert.ToInt32(SystemParameters.VirtualScreenHeight);
        int screenLeft = Convert.ToInt32(SystemParameters.VirtualScreenLeft);
        int screenTop = Convert.ToInt32(SystemParameters.VirtualScreenTop);
    
        Image imgScreen = new Bitmap(screenWidth, screenHeight);
        using (Bitmap bmp = new Bitmap(screenWidth, screenHeight, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        using (Graphics gr = Graphics.FromImage(imgScreen))
        {
            g.CopyFromScreen(screenLeft, screenTop, 0, 0, new Size(screenWidth, screenHeight));
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gr.DrawImage(bmp, new Rectangle(0, 0, screenWidth, screenHeight));
        }
    
        return imgScreen;
    }
