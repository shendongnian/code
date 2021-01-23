    public string Data
    {
        get { return _value.ToString(); }
        set
        {
            _value = (FooEnum)Enum.Parse(typeof(FooEnum), value);
            OnPropertyChanged("Data");
        }
    }
