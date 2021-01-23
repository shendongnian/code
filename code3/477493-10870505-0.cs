    public Bitmap ScreenShot()
    {
        var screenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                    Screen.PrimaryScreen.Bounds.Height,
                                    PixelFormat.Format32bppArgb);
        using (var g = Graphics.FromImage(screenShot))
        {
            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
        }
        return screenShot;
    }
