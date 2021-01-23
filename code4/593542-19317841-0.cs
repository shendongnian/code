    public DbTreeView()
    {
        // Enable default double buffering processing (DoubleBuffered returns true)
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        // Disable default CommCtrl painting on non-Vista systems
        if (Environment.OSVersion.Version.Major < 6)
            SetStyle(ControlStyles.UserPaint, true);
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        if (GetStyle(ControlStyles.UserPaint))
        {
            Message m = new Message();
            m.HWnd = Handle;
            m.Msg = WM_PRINTCLIENT;
            m.WParam = e.Graphics.GetHdc();
            m.LParam = (IntPtr)PRF_CLIENT;
            DefWndProc(ref m);
            e.Graphics.ReleaseHdc(m.WParam);
        }
        base.OnPaint(e);
    }
