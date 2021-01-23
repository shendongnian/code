    List<string> ListTimes = new List<string>() { "09.00 AM", "12.00 PM", "03.00 PM" };
    string testTimeString = "01.00 PM";
    DateTime testTime = DateTime.ParseExact(testTimeString, "hh.mm tt", CultureInfo.InvariantCulture);
    DateTime closestTime = DateTime.MinValue;
    TimeSpan closestDifference = TimeSpan.MaxValue;
    
    foreach (string item in ListTimes)
    {
        DateTime itemTime = DateTime.ParseExact(item, "hh.mm tt", CultureInfo.InvariantCulture);
        TimeSpan itemDifference = (itemTime - testTime).Duration();
    
        if (itemDifference < closestDifference)
        {
            closestTime = itemTime;
            closestDifference = itemDifference;
        }
    }
    return closestTime.ToString("hh.mm tt");
