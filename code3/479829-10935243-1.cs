    public string Forename
    {
        get{ return _forename; }
        set
        {
            if(value != _forename)
            {
                _forename = value;
                RaisePropertyChanged("Forename");
                UpdateFullName();
            }
        }
    }
    private void UpdateFullName()
    {  
        FullName = string.Format("{0} {1}", this.Forename, this.Surname); 
    }
    public string FullName
    {
        get{ return _fullname; }
        private set
        {
            if(value != _fullname)
            {
                _fullname = value;
                RaisePropertyChanged("FullName");
            }
        }
    }
