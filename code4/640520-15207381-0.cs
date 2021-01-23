    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        IntPtr hdc = pevent.Graphics.GetHdc();
        Rectangle rect = this.ClientRectangle;
        NativeMethods.DrawThemeParentBackground(this.Handle, hdc, ref rect);
        pevent.Graphics.ReleaseHdc(hdc);
    }
    
    
    internal static class NativeMethods
    {
        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref Rectangle pRect);
    }
