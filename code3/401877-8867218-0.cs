    public DateTime Date
    {
        get { return date; }
        set
        {
            if (value != this.date)
            {
                this.date = value;
                setActualDate(this.date);
    RaisePropertyChanged("Date");
    RaisePropertyChanged("NewDate");
    RaisePropertyChanged("ZodiacString");
                
            }
        }
    }
    
    
    private void RaisePropertyChanged(string propertyName)
    {
    if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
                }
    }
    
    public String ZodiacString
    {
        get { 
    zodiac = MoonCalculus.getZodiac();
       ...
    return zodiac; }
    }
