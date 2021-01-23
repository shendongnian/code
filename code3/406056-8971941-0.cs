    protected override void WndProc(ref Message m) {
        // Trap WM_PASTE:
        if (m.Msg == 0x302) {
            //Paste occurred
        }
        base.WndProc(ref m);
    }
