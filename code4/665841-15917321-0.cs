    private string _myProperty;
    public string MyProperty
    {
        get { return _myProperty; }
        set
        {
            if (value == String.Empty)
            {
                _myProperty = null;
            }
            else
            {
                _myProperty = value;
            }
        }
    }
