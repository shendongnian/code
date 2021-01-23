    string _selected;
    public string Selected
    {
        get { return _selected; }
        set 
        { 
            _selected= value; 
            OnPropertyChanged("Selected");
            OnPropertyChanged("ValueFromKey");
        }
    }
    public string[] ValueFromKey
    {
        get { return Items[Selected]; }
    }
