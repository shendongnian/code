    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public int Width { get { return this.Right - this.Left; } }
        public int Height { get { return this.Bottom - this.Top; } }
    }
    
    [DllImport("user32.dll")]
    internal static extern bool GetUpdateRect(IntPtr hWnd, ref Rect rect, bool bErase);
    
    public static bool IsControlVisibleToUser(Control control)
    {
        control.Invalidate();
        var bounds = control.Bounds;
        var rect = new Rect {Left=bounds.Left, Right = bounds.Right, Top = bounds.Top, Bottom = bounds.Bottom};
        return GetUpdateRect(control.Handle, ref rect, false);
    }
