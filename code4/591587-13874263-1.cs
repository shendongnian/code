    TimeSpan startTime = new TimeSpan(7,0,0);
    TimeSpan endTime = new TimeSpan(2, 59, 0);
    if (DateTime.Now.TimeOfDay >= startTime &&
        DateTime.Now.TimeOfDay <= endTime)
    {
        //in range
    }
    else
    {
        //not in range. 
    }
