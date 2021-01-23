    static string GetValue(DateTime date)
    {
        var time = date.TimeOfDay;
        if (time.TotalHours >= 6 && time.TotalHours <= 14)
        {
            return "A";
        }
    
        if (time.TotalHours >= 14 && time.TotalHours <= 22)
        {
            return "B";
        }
    
        return null;
    }
