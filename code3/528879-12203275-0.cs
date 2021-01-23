    private bool _endDateEnabled;
    public bool EndDateEnabled
    {
        get { return _endDateEnabled; }
        set
        {
            _endDateEnabled = value;
            OnPropertyChanged("EndDateEnabled");
        }
    }
