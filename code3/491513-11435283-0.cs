    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        base.WndProc(ref m);
    
        const int WM_MOUSEHWHEEL = 0x020E;
        if (m.Msg == WM_MOUSEHWHEEL)
        {
            m.Result = new IntPtr(HIWORD(m.WParam) / WHEEL_DELTA);
        }
    }
