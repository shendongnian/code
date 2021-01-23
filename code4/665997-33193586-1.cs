    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x10) // The upper right "X" was clicked
        {
            this.ActiveControl = null;
            this.AutoValidate = AutoValidate.Disable;
        }
        base.WndProc(ref m);
     }
