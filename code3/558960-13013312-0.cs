    public  List<string> DatabaseList
    {
        get
        {
            return _dblist;
        }
        set
        {
            if (_dblist != value)
            {
                _dblist = value;
                OnPropertyChanged("DatabaseList");
            };
        }
    }
