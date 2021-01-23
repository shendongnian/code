    public decimal First
    {
        get { return first; }
        set
        {
            if(first == value)
                return;
            first = value;
            NotifyPropertyChanged("First");
        }
    }
