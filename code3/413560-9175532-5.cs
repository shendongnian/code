    protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
    {
        int _ENTER = 13;
           
        if (m.Msg == _ENTER)
        {
            //Do nothing
        }
        return base.ProcessKeyPreview(ref m);
    }
