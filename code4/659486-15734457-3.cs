    public event ValueChangedHandler ValueChanged = delegate {};
    public T Value
    {
        get { return m_Value; }
        set
        {
            //first change
			m_Value = value;
            //now notify
            ValueChanged(m_Value, value);
            
        }
    }
