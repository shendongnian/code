    IControlExtender _extender = new DefaultExtender();
    public IControlExtender Extender
    {
        get { return _extender; }
        set
        {
            if ((value != null) && (value != _extender))
            {
                _extender = value;
                RefreshControl();
            }
        }
    }
    
    void RefreshControl()
    {
        this.BackColor = Extender.BackColor;
    }
