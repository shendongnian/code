    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams param = base.CreateParams;
            const int WS_CAPTION = 0x00C00000;
            param.ClassStyle = param.ClassStyle & ~WS_CAPTION; // Turn off caption.
            return param;
        }
    }
