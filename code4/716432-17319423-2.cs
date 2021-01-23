    public event EventHandler OnMyNameSet;
    public event EventHandler OnMyNameGet;
    public string MyName
    {
        get
        {
            if (OnMyNameSet != null) { OnMyNameSet(this, EventArgs.Empty); }
            return m_ASD;
        }
        set
        {
            if (OnMyNameSet != null) { OnMyNameGet(this, EventArgs.Empty); }
            m_ASD = value;
        }
    }
