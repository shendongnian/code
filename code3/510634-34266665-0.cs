    DateTime timeNow = DateTime.Now;
    DateTime fromTime = new DateTime(2015, 11, 14, 08, 00, 00);
    DateTime toTime = new DateTime(2015, 11, 14, 14, 30, 00);
    if (TimeSpan.Compare(timeNow.TimeOfDay, fromTime.TimeOfDay) == 1 && TimeSpan.Compare(timeNow.TimeOfDay, toTime.TimeOfDay) == -1)  
    {
    }
