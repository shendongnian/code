    Dictionary<DateTime,int> dict = new Dictionary<DateTime,int>();
    
    void Set(DateTime date, int hours)
    {
        if (dict.Contains(date)) dict.Remove(date);
    
        var normalised_date = new DateTime(date.Year,date.Month,date.Day,0,0,0);
    
        dict.Add(normalised_date,hours);
    }
    
    bool HasHoursForDate(DateTime date)
    {
        var normalised_date = new DateTime(date.Year,date.Month,date.Day,0,0,0);
    
        return dict.Contains(normalised_date);
    }
    
    int GetHoursForDate(DateTime date)
    {
        var normalised_date = new DateTime(date.Year,date.Month,date.Day,0,0,0);
    
        return dict[normalised_date ];
    }
    
    Set(DateTime.Now,8);
