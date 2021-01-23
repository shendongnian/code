    string _Description;
    public string Description
    {
        get
        {
            return _Description;
        }
        set
        {
            _Description = value;
            OnPropertyChanged("Description");
        }
    }
