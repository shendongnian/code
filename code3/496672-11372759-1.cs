    //Create a list of DateTimes including the start date, with the specified
    //number of days in between each item in the list.
    public static IList<DateTime> GetRepeatingEvents(DateTime start, DateTime end, int intervalInDays)
    {
      List<DateTime> allEvents = new List<DateTime>();
      allEvents.Add(start); //Make sure the start date is included in the list of dates!
    
      var tempDate = start;
      while (tempDate <= end) //Less than or Equals means the end date will be added as well
      {
        tempDate = tempDate.AddDays(intervalInDays);
        allEvents.Add(tempDate);
      }
      return allEvents;
    }
