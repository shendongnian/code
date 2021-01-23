    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    // Make sure RECT is actually OUR defined struct, not the windows rect.
    public static RECT GetWindowRectangle(Window window)
    {
        RECT rect;
        GetWindowRect((new WindowInteropHelper(window)).Handle, out rect);
        return rect;
    }
