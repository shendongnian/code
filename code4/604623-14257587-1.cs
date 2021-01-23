    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams param = base.CreateParams;
            const int CS_DROPSHADOW = 0x00020000;
            const int WS_CAPTION    = 0xC00000;
            param.ClassStyle = param.ClassStyle | CS_DROPSHADOW; // Turn on window shadow.
            param.Style = param.Style & ~WS_CAPTION; // Turn off caption.
            return param;
        }
    }
