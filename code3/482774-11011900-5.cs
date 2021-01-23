    private DateTime _startDate;
    public DateTime StartDate
    {
        get { return _startDate; }
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentException(string.Format("Start Date must not be in the past: {0}", value.ToString()));
            _startDate = value;
        }
    }
