    public boolean bulk = false;
    public string Name
    {
        get { return _Name; }
        set
        {
            if (_Name == value)
            {
                return;
            }
            _Name = value;
            _Modified = true;
            OnPropertyChanged(new PropertyChangedEventArgs("Name"));
        }
    }
