    private string _name;
    public string Name 
    { 
        get { return _name; } 
        set 
        {
            _name = value;
            if (_name != value && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
        } 
    }
