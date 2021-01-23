    TimeSpan start = new TimeSpan(17, 30, 0); // 5:30 pm
    TimeSpan stop = new TimeSpan(20, 45, 0); // 8:45 pm
    if (DateTime.Now.TimeOfDay >= start && DateTime.Now.TimeOfDay <= stop)
    {
        // ... do something ...
    }
