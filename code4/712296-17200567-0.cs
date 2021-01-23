    if (!this.ItsPartyDay() && (this.ItsLunchTime() || this.ItsDinnerTime()))
    {
        ...
    }
    private bool ItsPartyDay()
    {
        return (Int32)DateTime.Now.DayOfWeek >= 5;
    }
    private bool ItsLunchTime()
    {
        return (DateTime.Now.Hour >= 10 && DateTime.Now.Hour < 13);
    }
    
    private bool ItsDinnerTime()
    {
        return (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 23);
    }
