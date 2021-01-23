    public void DrawCursorToImage(Image img, Point cursorOffset)
    {
        if (IconHandle != IntPtr.Zero)
        {
            Point drawPosition = new Point(Position.X - cursorOffset.X, Position.Y - cursorOffset.Y);
            using (Graphics g = Graphics.FromImage(img))
            {
                IntPtr hdc = g.GetHdc();
                using (Graphics gfx = Graphics.FromHdc(hdc))
                {
                    // For some reason it is necessary to redraw the image here
                    gfx.DrawImage(img, 0, 0);
                    gfx.DrawIcon(Icon.FromHandle(IconHandle), drawPosition.X, drawPosition.Y);
                }
                g.ReleaseHdc();
            }
        }
    }
