    public static IEnumerable<IntPtr> EnumerateIEDwmThumbnails()
    {
        List<IntPtr> ptrs = new List<IntPtr>();
        StringBuilder cls = new StringBuilder(100);
        EnumWindows((hwnd, lparam) =>
        {
            GetClassName(hwnd, cls, cls.Capacity);
            if (cls.ToString() == "TabThumbnailWindow")
            {
                ptrs.Add(hwnd);
            }
            return true;
        }, IntPtr.Zero);
        return ptrs;
    }
    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsCallback lpEnumFunc, IntPtr lParam);
    private delegate bool EnumWindowsCallback(IntPtr hwnd, IntPtr lParam);
    [DllImport("user32.dll")]
    private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
