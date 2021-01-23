    public bool PositionModifiedByUser
    { /* implement IPropertyChanged if need to bind to this property */ }
    // use this property from code
    public double Position
    {
        get { return m_position ; }
        set { SetPropertyValue ("PositionUI", ref m_position, value) ;
              PositionModifiedByUser = false ; }
    }
    // bind to this property from the UI
    public double PositionUI
    {
        get { return m_position ; }
        set { if (SetPropertyValue ("PositionUI", ref m_position, value))
              PositionModifiedByUser = true ; }
    }
