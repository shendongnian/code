    DateTime appDate = new DateTime(2012, 10, 18, 16, 9, 41);
    TimeSpan diff = DateTime.Now.Subtract(appDate);
    if(diff.Hours > 30)
    {
        // Application older than 30 hours
    }
