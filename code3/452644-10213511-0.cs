    public string Name
    {
        get { return name; }
        set 
        { 
            if(value != name)
            {
                name = value;
                OnPropertyChanged("Name"); 
            }
        }
    }
