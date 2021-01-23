    private string _myValue;
    public string MyValue
    {
        get { return _value; }
        set
        {
            _myValue = value;
            NotifyOfPropertyChanged("MyValue");
        }
    }
