    protected override void WndProc(ref Message m) 
    {
        if (m.Msg == WM_CANCELJOURNAL)
        {
            Stop();
        }
        base.WndProc(ref m);
    }
