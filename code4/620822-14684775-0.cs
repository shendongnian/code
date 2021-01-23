    public string plcIp
    {
        get
        {
            return _plcIp;
        }
        set
        {
            if (value != _plcIp)
            {
                _plcIp = value;
                OnPropertyChanged();
            }
        }
    }
