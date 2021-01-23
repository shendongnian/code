    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    private void ScrollMenu(object sender, MouseEventArgs e)
    {
        Point origin = Cursor.Position;
        int clicks;
        if (e.Delta < 0)
        {
            Cursor.Position = menu.PointToScreen(new Point(menu.DisplayRectangle.Left + 5, menu.DisplayRectangle.Bottom + 5));
            clicks = e.Delta / -40;
        }
        else
        {
            Cursor.Position = menu.PointToScreen(new Point(menu.DisplayRectangle.Left + 5, menu.DisplayRectangle.Top - 5));
            clicks = e.Delta / 40;
        }
        for (int i = 0; i < clicks; i++)
            mouse_event(0x0006, 0, 0, 0, 0);//Left mouse button up and down on cursor position
        Cursor.Position = origin;
    }
