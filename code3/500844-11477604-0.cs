    private const int WM_HOTKEY = 0x312;
    
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
    
        if (m.Msg == WM_HOTKEY)
        {
            if (!Visible)
                Visible = true;
            Activate();
            label.Text = "Hello World";
        }
    }
