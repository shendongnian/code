    public Action OnMyNameSet { get; set; }
    public Action OnMyNameGet { get; set; }
    public string MyName
    {
        get
        {
            if (OnMyNameSet != null) { OnMyNameSet(); }
            return m_ASD;
        }
        set
        {
            if (OnMyNameSet != null) { OnMyNameGet(); }
            m_ASD = value;
        }
    }
