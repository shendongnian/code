    private const Int32 WM_NCHITTEST = 0x84;
    private const Int32 HTCLIENT = 0x1;
    private const Int32 HTCAPTION = 0x2;
    protected override void WndProc(ref Message m)
    {
        switch(m.Msg)
        {
            case WM_NCHITTEST :
            {
                base.WndProc(ref m);
                if ((Int32)m.Result == HTCLIENT)
                    m.Result = (IntPtr)HTCAPTION ;
                return;
            }
        }
    
        base.WndProc(ref m);
    }
