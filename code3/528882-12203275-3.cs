    private bool _endDateEnabled;
    public bool EndDateEnabled
    {
        get { return _endDateEnabled; }
        set
        {
            if (value != _endDateEnabled)
            {
                _endDateEnabled = value;
                OnPropertyChanged("EndDateEnabled");
            }
        }
    }
