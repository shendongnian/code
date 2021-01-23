    public name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            PropertyChanged("name");
        }
    }
