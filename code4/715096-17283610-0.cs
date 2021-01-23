    public String Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged("Name");
            OnPropertyChanged("DisplayName");
        }
    }
    
    public string DisplayName
    {
        get { return _display_name ?? _name; }
        set
        {
            _display_name = value;
            OnPropertyChanged("DisplayName");
        }
    }
