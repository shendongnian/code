    // In ViewModel
    private DateTime dateTime;
    public DateTime Date
    {
        get { return dateTime.Date; }
        set
        {
            if (value != dateTime.Date)
            {
                dateTime = value.Date + dateTime.TimeOfDay;
                RaisePropertyChanged("Date");
            }
        }
    }
     
    public TimeSpan Time
    {
        get { return dateTime.TimeOfDay; }
        set
        {
            if (value != dateTime.TimeOfDay)
            {
                dateTime = dateTime.Date + value;
                RaisePropertyChanged("Time");
            }
        }
    }
