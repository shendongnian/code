    public String Name
    {
        get { return name; }
        set
        {
            if (name == value) return;
            name = value;
            OnPropertyChanged("Name");
        }
    }
