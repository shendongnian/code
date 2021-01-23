    const int WM_DWMCOLORIZATIONCOLORCHANGED = 0x320;
    private IntPtr hwnd;
    private HwndSource hsource;
    
    private void Window_SourceInitialized(object sender, EventArgs e)
    {
        if ((hwnd = new WindowInteropHelper(this).Handle) == IntPtr.Zero)
        {
            throw new InvalidOperationException("Could not get window handle.");
        }
    
        hsource = HwndSource.FromHwnd(hwnd);
        hsource.AddHook(WndProc);
    }
    private static Color GetWindowColorizationColor(bool opaque)
    {
        var params = NativeMethods.DwmGetColorizationParameters();
        return Color.FromArgb(
            (byte)(opaque ? 255 : params.ColorizationColor >> 24), 
            (byte)(params.ColorizationColor >> 16), 
            (byte)(params.ColorizationColor >> 8), 
            (byte) params.ColorizationColor
        );
    }
    
    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        switch (msg)
        {
            case WM_DWMCOLORIZATIONCOLORCHANGED:
    
                /* 
                 * Update gradient brushes with new color information from
                 * NativeMethods.DwmGetColorizationParams() or the registry.
                 */
    
                return IntPtr.Zero;
    
            default:
                return IntPtr.Zero;
        }
    }
