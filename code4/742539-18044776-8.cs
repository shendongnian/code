    DateTime local1 = new DateTime(2013, 11, 3, 0, 0, 0, DateTimeKind.Local);
    DateTime local2 = local1.AddDays(1);
    DateTime utc1 = local1.ToUniversalTime();
    DateTime utc2 = utc1.AddDays(1);
    DateTime local3 = utc2.ToLocalTime();
    Debug.WriteLine(local2); //  11/4/2013 12:00:00 AM
    Debug.WriteLine(local3); //  11/3/2013 11:00:00 PM
