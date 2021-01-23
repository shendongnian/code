    public string Sql
    {
        get { return _sql; }
        set
        {
            if (value == _sql) return;
            OnPropertyChanged("Sql");
            _sql = value;
        }
    }
