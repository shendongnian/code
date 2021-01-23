    public static Bitmap takeComponentScreenShot(Control control)
    {
        // find absolute position of the control in the screen.
        Rectangle rect=browser.RectangleToScreen(browser.Bounds);
        Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(bmp);
        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
        return bmp;
    }
