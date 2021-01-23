    protected override void WndProc(ref Message m)
    {
        if (m.Msg == Media.MM_MCINOTIFY)
        {
            do smthing..
        }
        base.WndProc(ref m);
    }
