    [DllImport("User32.dll")]
    public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags
    
    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    
    public static Bitmap GetWindow(IntPtr hWnd)
    {
        RECT rect;
        GetWindowRect(hWnd, out rect);
        
        int width = rect.Right - rect.Left;
        int height = rect.Bottom - rect.Top;
        if (width > 0 && height > 0)
        {
            // Build device context (dc)
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();
            
            // drawing options
            int nFlags = 0;
            
            // execute call
            PrintWindow(hWnd, hdcBitmap, nFlags);
            
            // some clean-up
            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();
            
            return bmp;
        }
        else
        {
            return null;
        }
    } // end function getWindow
