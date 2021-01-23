    Dictionary<DateTime,int> dict = new Dictionary<DateTime,int>();
    
    void Set(DateTime date, int hours)
    {
        if (dict.Contains(date)) dict.Remove(date);
        dict.Add(date.Date,hours);
    }
    
    bool HasHoursForDate(DateTime date)
    {
        return dict.Contains(date.Date);
    }
    
    int GetHoursForDate(DateTime date)
    {
        return dict[date.Date];
    }
    
    Set(DateTime.Now,8);
