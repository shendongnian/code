    DateTime testTime = DateTime.ParseExact("hh.mm tt");
    DateTime closestTime = DateTime.MinValue;
    TimeSpan closestDifference = TimeSpan.MaxValue;
    foreach (string item in listItems)
    {
        DateTime itemTime = DateTime.ParseExact("hh.mm tt");
        TimeSpan itemDifference = (itemTime - testTime).Duration();
        if (itemDifference < closestDifference)
        {
            closestTime = itemTime;
            closestDifference = itemDifference;
        }
    }
    return closestTime.ToString("hh.mm tt");
