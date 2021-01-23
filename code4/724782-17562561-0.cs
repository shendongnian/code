    public DateTime GetLastPosibleDate(DateTime datetime, List<DayOfWeek> days)
    {
        DateTime dt = datetime;
        if (!days.Any(d=> d==dt.DayOfWeek))
        {
            dt=  GetLastPosibleDate(datetime.AddDays(-1), days);
        }
        return dt;
    }
    
    public DateTime EstimatedDiliveryDate(DateTime arrival, int transitDays, List<DayOfWeek> deliveryDays)
    {
        return GetLastPosibleDate(arrival.AddDays(-transitDays), deliveryDays);
    }
