    protected override void WndProc(ref Message m)
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
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
