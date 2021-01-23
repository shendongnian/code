    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
    
        if (m.Msg == 0x302) //WM_PASTE
        {
            // Do your magic
        }
    }
