    internal static class NativeWinAPI
    {
        [Flags]
        internal enum DrawingOptions
        {
            PRF_CHECKVISIBLE = 0x01,
            PRF_NONCLIENT = 0x02,
            PRF_CLIENT = 0x04,
            PRF_ERASEBKGND = 0x08,
            PRF_CHILDREN = 0x10,
            PRF_OWNED = 0x20
        }
        internal const int WM_PRINT = 0x0317;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg,
            IntPtr wParam, IntPtr lParam);
    }
    public static void TakeScreenshot(IntPtr hwnd, Graphics g)
    {
        IntPtr hdc = IntPtr.Zero;
        try
        {
            hdc = g.GetHdc();
            NativeWinAPI.SendMessage(hwnd, NativeWinAPI.WM_PRINT, hdc,
                new IntPtr((int)(
                    NativeWinAPI.DrawingOptions.PRF_CHILDREN |
                    NativeWinAPI.DrawingOptions.PRF_CLIENT |
                    NativeWinAPI.DrawingOptions.PRF_NONCLIENT |
                    NativeWinAPI.DrawingOptions.PRF_OWNED
                    ))
                );
        }
        finally
        {
            if (hdc != IntPtr.Zero)
                g.ReleaseHdc(hdc);
        }
    }
