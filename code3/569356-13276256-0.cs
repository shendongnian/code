    private int _MyProperty;
    public int MyProperty
    {
        get { return _MyProperty; }
        set { _MyProperty = value; OnPropertyChanged("MyProperty")}
    }
