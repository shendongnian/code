    private const int WM_HOTKEY = 0x312;
    
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
    
        if (m.Msg == WM_HOTKEY)
        {
            if (!Visible)
                Visible = true;
            Activate();
            Keys vk = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
            int fsModifiers = ((int)m.LParam & 0xFFFF);
            if (vk == Keys.F1 && sModifiers == 0)
                label.Text = "Hello World";
        }
    }
