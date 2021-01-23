    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    [DllImport("User32.dll")]
    private static extern IntPtr GetWindowDC(IntPtr hWnd);
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        const int WM_NCPAINT = 0x85;
        if (m.Msg == WM_NCPAINT)
        {
            IntPtr hdc = GetWindowDC(m.HWnd);
            if ((int)hdc != 0)
            {
                Graphics g = Graphics.FromHdc(hdc);
                g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4800, 23));
                g.Flush();
                ReleaseDC(m.HWnd, hdc);
            }
        }
    }
