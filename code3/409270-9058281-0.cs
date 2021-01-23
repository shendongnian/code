    public void SimLeftClick(int x, int y)
    {
        var scr = Screen.PrimaryScreen.Bounds;
        SimMouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Move | MouseEventFlags.Absolute,
            (int)(x / (double)scr.Width * 65535),
            (int)(y / (double)scr.Height * 65535));
    }
