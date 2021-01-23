    public Action OnMyNameSet { get; set; }
    public Action OnMyNameGet { get; set; }
    public string MyName
    {
        get
        {
            if (OnMyNameGet != null) { OnMyNameGet(); }
            return m_ASD;
        }
        set
        {
            if (OnMyNameSet != null) { OnMyNameSet(); }
            m_ASD = value;
        }
    }
