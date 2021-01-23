    protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        // 0x115 and 0x20a both tell the control to scroll. If either one comes 
        // through, you can handle the scrolling before any repaints take place
        if (m.Msg == 0x115 || m.Msg == 0x20a) 
        {
            //Do you scroll processing
        }
    }
