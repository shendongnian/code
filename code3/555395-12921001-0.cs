    public DateTime YourDateTimeProperty
    {
        get { return _dateTime; }
        set { _dateTime = value.ToLocalTime(); }
    }
