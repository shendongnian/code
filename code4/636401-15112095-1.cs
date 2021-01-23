    string _startDate;
    public string StartDate
    {
        get { return _startDate; }
        set
        {
            _startDate = value;
            OnPropertyChanged("StartDate");
        }
    }
