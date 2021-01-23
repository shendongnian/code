    TimeSpan startTime = DateTime.Today.AddHours(7).TimeOfDay; // 07:00 AM
    TimeSpan endTime = DateTime.Today.AddHours(14).AddMinutes(59).TimeOfDay; //02:59 PM
    if (DateTime.Now.TimeOfDay >= startTime &&
        DateTime.Now.TimeOfDay <= endTime)
    {
        //in range
    }
    else
    {
        //not in range. 
    }
