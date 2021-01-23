    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 0x7b) {  //WM_CONTEXTMENU
            if (m.LParam != this.Handle) HeaderContextMenu.Show(Control.MousePosition);
        }
    }
