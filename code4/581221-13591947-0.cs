    private string _someProperty;
    public string SomeProperty
    {
        get { return _someProperty; }
        set
        {
            _someProperty = value;
            OnPropertyChanged("SomeProperty");
        }
    }
