    public string _PhoneNumber
    public string PhoneNumber
    {
        get
        {
            return _PhoneNumber;
        }
        set
        {
            if (value != PhoneNumber)
            {
                _PhoneNumber = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }
    }
