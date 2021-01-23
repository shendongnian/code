    public double value
    {
        get { return _value; }
        set 
        {
            _value = value;
            if (_changed != null)
            {
                _changed(this, EventArgs.Empty);
            }
        }
    }
    private double _value = 0;
