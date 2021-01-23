    public static void GoDrawPixel(PixelChangedEventHandler pixelChanged,
        int x, int y, bool enabled)
    {
        if (pixelChanged != null)
        {
            pixelChanged.Invoke(new PixelChangedEventArgs(x, y, enabled));
        }
    }
