    public static Bitmap CaptureScreen256()
    {
        Rectangle bounds = SystemInformation.VirtualScreen;
    
        using (Bitmap Temp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format24bppRgb))
        {
            using (Graphics g = Graphics.FromImage(Temp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Temp.Size);
            }
    
            return Temp.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format8bppIndexed);
        }
    }
