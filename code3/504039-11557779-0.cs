    DateTime GetDate(DateTime now, DayOfWeek dayOfWeek)
    {
        var day = new TimeSpan(1, 0, 0, 0);
        var result = now;
        while(result.DayOfWeek != dayOfWeek)
        {        
            result = result.Substract(day)
        }
        return result;
    } 
