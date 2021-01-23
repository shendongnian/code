    public string Forename
    {
        get{ return _forename; }
        set
        {
            if(value != _forename)
            {
                _forename = value;
                RaisePropertyChanged("Forename");
                RaisePropertyChanged("Fullname");
            }
        }
    }
