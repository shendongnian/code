    public double MyProperty
    {
        get
        {
            return _myProperty;
        }
        set
        {
            if (Abs(value - _myProperty) / (Max(Abs(value), Abs(_myProperty)) + double.Epsilon) > MyEpsilon)
            {
                _myProperty = value;
                NotifyPropertyChanged("MyProperty");
            }
        }
    }
