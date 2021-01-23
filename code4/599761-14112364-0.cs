    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            ...
            case WM_NCCALCSIZE:
            {
                base.WndProc(ref m);
                //Work your magic...
            }
            default: base.WndProc(ref m);
        }
    }
