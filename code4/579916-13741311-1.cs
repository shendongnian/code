    bool ShowBtn
    {
        get{ return _ShowDefault; }
        set
        {
            Btn_Default.Visible = value;
            _ShowDefault = value; 
        }
    }
    bool _ShowDefault = true;
