    public double MyProperty
    {
        get
        {
            return _myProperty;
        }
        set
        {
            if (value != _myProperty)
            {
                _myProperty = value;
                NotifyPropertyChanged("MyProperty");
            }
        }
    }
