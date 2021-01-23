    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x16) // WM_ENDSESSION
        {
            WaitForQueriesToFinishOrSaveState();
            m.Result = IntPtr.Zero;
            return;
        }
        base.WndProc(ref m);
    }
