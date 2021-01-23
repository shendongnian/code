    private void MakeTransparent()
    {
        IntPtr mainWindowPtr = new WindowInteropHelper(this).Handle;
        HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
        mainWindowSrc.CompositionTarget.BackgroundColor = System.Windows.Media.Color.FromArgb(0, 0, 0, 0);
    
        Graphics desktop = Graphics.FromHwnd(mainWindowPtr);
        float DesktopDpiX = desktop.DpiX;
        float DesktopDpiY = desktop.DpiY;
    
        MARGINS margins = new MARGINS()
        {
            cxLeftWidth = 0,
            cxRightWidth = Convert.ToInt32(Width) * Convert.ToInt32(Width),
            cyTopHeight = 0,
            cyBottomHeight = Convert.ToInt32(Height) * Convert.ToInt32(Height)
        };
    
        int hr = DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }
    
    [DllImport("DwmApi.dll")]
    public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS pMarInset);
