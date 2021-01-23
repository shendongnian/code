    const int WM_SYSCOMMAND = 0x0112;
    const int SC_MINIMIZE = 0xF020;
    const int SC_MAXIMIZE = 0xF030;
    const int SC_RESTORE = 0xF120;
    const int SC_TOP = 0xF003;
    const int SC_LEFTTOP = 0xF004;
    const int SC_RIGHTTOP = 0xF005;
    const int SC_DBCLICKTITLEBARMAX = 0xF122;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m); 
        if (m.Msg == WM_SYSCOMMAND)
        {
            int sc = m.WParam.ToInt32();
            if (sc == SC_RESTORE | sc == SC_LEFTTOP | sc == SC_TOP | sc == SC_RIGHTTOP | sc == SC_DBCLICKTITLEBARMAX )
            {
                FormBorderStyle oldvalue = this.FormBorderStyle;
                this.FormBorderStyle = FormBorderStyle.None;
                this.FormBorderStyle = oldvalue;
            }
        }
    }
