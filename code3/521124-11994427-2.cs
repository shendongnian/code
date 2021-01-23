    [DllImport("User32.dll")]
    public static extern IntPtr GetDC(IntPtr hwnd);
    
    [DllImport("User32.dll")]
    public static extern void ReleaseDC(IntPtr dc);
    
    void OnPaint()
    {
        IntPtr desktopDC=GetDC(IntPtr.Zero);
    
        Graphics g = Graphics.FromHdc(desktopDC);
    
        g.DrawImage(bitmap, pointer.X - 50, pointer.Y - 50, 100, 100);
    
        g.Dispose();
        ReleaseDC(desktopDC);
    
    }
