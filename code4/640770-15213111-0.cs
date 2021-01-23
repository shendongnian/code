    public string Field
    {
        get { return _field; }
        set
        {
            var val = MakeNumeric(value)
            _field = value;
            OnPropertyChanged("Field");
        }
    }
