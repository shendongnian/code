    public static void MouseLeftClick(Point p)
    {
         int coordinates = p.X | (p.Y << 16);
         PostMessage(0, Messages.WM_LBUTTONDOWN, 0x1, coordinates);
         PostMessage(0, Messages.WM_LBUTTONUP, 0x1, coordinates);
    }
    
    public static void MouseRightClick(Point p)
    {
         int coordinates = p.X | (p.Y << 16);
         PostMessage(0, Messages.WM_RBUTTONDOWN, 0x1, coordinates);
         PostMessage(0, Messages.WM_RBUTTONUP, 0x1, coordinates);
    }
