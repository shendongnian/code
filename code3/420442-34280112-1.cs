    protected override void WndProc(ref Message m) 
    {
        if(m.Msg == 0xF)
            foreach(Control c in this.Controls) c.Invalidate();
        base.WndProc(ref m);
    }
