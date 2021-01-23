    public object MyObject
    {
        get { ... }
        set
        {
            ...
            OnPropertyChanged("MyObject");
            OnPropertyChanged("MyCollection");
            OnPropertyChanged("MyBoolean");
        }
    }
