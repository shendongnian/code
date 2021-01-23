    private const int WM_NCHITTEST = 0x84;
    private const int HTCLIENT = 0x1;
    
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_NCHITTEST:
                m.Result = (IntPtr)HTCLIENT;
                return;
        }
        base.WndProc(ref m);
    }
