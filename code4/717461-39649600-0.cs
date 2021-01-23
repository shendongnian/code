    [DllImport("user32.dll")]
    static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
 
    public Bitmap printWindow()
    {
         RECT clientRect;
         GetClientRect(WindowHandle, out clientRect);
         RECT windowRect;
         GetWindowRect(WindowHandle, out windowRect);
         int borderSize = (windowRect.Width - clientRect.Width) / 2;
         int titleBarSize = (windowRect.Height - clientRect.Height) - borderSize;
         PrintWindow(MainWindowHandle, hdcBitmap, 0);
          
         gfxBmp.ReleaseHdc(hdcBitmap);
         gfxBmp.Dispose();
         Bitmap bmp = bmp.Clone(new Rectangle(borderSize, titleBarSize, bmp.Width - 2*borderSize, bmp.Height - titleBarSize-borderSize), PixelFormat.Format32bppRgb);
         
         return bmp;
    }
