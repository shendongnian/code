    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
    }
    public enum SpecialWindowHandles
    {
        HWND_TOP = 0,
        HWND_BOTTOM = 1,
        HWND_TOPMOST = -1,
        HWND_NOTOPMOST = -2
    }
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    public static readonly DependencyProperty WindowHeightAnimationProperty = DependencyProperty.Register("WindowHeightAnimation", typeof(double),
                                                                                                typeof(MainWindow), new PropertyMetadata(OnWindowHeightAnimationChanged));
    private static void OnWindowHeightAnimationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var window = d as Window;
        if (window != null)
        {
            IntPtr handle = new WindowInteropHelper(window).Handle;
            var rect = new RECT();
            if (GetWindowRect(handle, ref rect))
            {
                rect.X = (int)window.Left;
                rect.Y = (int)window.Top;
                    
                rect.Width = (int)window.ActualWidth;
                rect.Height = (int)(double)e.NewValue;  // double casting from object to double to int
                SetWindowPos(handle, new IntPtr((int)SpecialWindowHandles.HWND_TOP), rect.X, rect.Y, rect.Width, rect.Height, (uint)SWP.SHOWWINDOW);
            }
        }
    }
    public double WindowHeightAnimation
    {
        get { return (double)GetValue(WindowHeightAnimationProperty); }
        set { SetValue(WindowHeightAnimationProperty, value); }
    }
    public static readonly DependencyProperty WindowWidthAnimationProperty = DependencyProperty.Register("WindowWidthAnimation", typeof(double),
                                                                                                typeof(MainWindow), new PropertyMetadata(OnWindowWidthAnimationChanged));
    private static void OnWindowWidthAnimationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var window = d as Window;
        if (window != null)
        {
            IntPtr handle = new WindowInteropHelper(window).Handle;
            var rect = new RECT();
            if (GetWindowRect(handle, ref rect))
            {
                rect.X = (int)window.Left;
                rect.Y = (int) window.Top;
                var width = (int)(double)e.NewValue;
                rect.Width = width;
                rect.Height = (int) window.ActualHeight;
                SetWindowPos(handle, new IntPtr((int)SpecialWindowHandles.HWND_TOP), rect.X, rect.Y, rect.Width, rect.Height, (uint)SWP.SHOWWINDOW);
            }
        }
    }
    public double WindowWidthAnimation
    {
        get { return (double)GetValue(WindowWidthAnimationProperty); }
        set { SetValue(WindowWidthAnimationProperty, value); }
    }
    private void GrowClick(object sender, RoutedEventArgs e)
    {
        this.AnimateWindowSize(Width+200, Height+200);
    }
    /// <summary>
    /// SetWindowPos Flags
    /// </summary>
    public static class SWP
    {
        public static readonly int
        NOSIZE = 0x0001,
        NOMOVE = 0x0002,
        NOZORDER = 0x0004,
        NOREDRAW = 0x0008,
        NOACTIVATE = 0x0010,
        DRAWFRAME = 0x0020,
        FRAMECHANGED = 0x0020,
        SHOWWINDOW = 0x0040,
        HIDEWINDOW = 0x0080,
        NOCOPYBITS = 0x0100,
        NOOWNERZORDER = 0x0200,
        NOREPOSITION = 0x0200,
        NOSENDCHANGING = 0x0400,
        DEFERERASE = 0x2000,
        ASYNCWINDOWPOS = 0x4000;
    }
