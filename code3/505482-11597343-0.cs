    public const int WM_MOVING = 0x0216;
    public const int WM_NCLBUTTONDOWN = 0x00A1;
    public const int HT_CAPTION = 0x0002;
    
    private Rectangle _cursorClip = Rectangle.Empty;
    
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_NCLBUTTONDOWN:
                if (m.WParam.ToInt32() == HT_CAPTION)
                {
                    Point location = Cursor.Position;
                    Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
                    Rectangle formBounds = Bounds;
    
                    _cursorClip = Rectangle.FromLTRB(location.X + screenBounds.Left - formBounds.Left,
                                                     location.Y + screenBounds.Top - formBounds.Top,
                                                     location.X + screenBounds.Right - formBounds.Right,
                                                     location.Y + screenBounds.Bottom - formBounds.Bottom);
                }
                break;
            case WM_MOVING:
                Cursor.Clip = _cursorClip;
                break;
        }
        base.WndProc(ref m);
    }
