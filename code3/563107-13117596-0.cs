    public string display 
    { 
        get { return _display; }
        set
        {
            if (_display != value)
            {
                _display = value;
                OnPropertyChanged("display");
            }
        } 
    }
    private string _display;
