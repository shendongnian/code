    var dict = new Dictionary<int, List<DateTime>>();
    foreach (var date in collectionOfDateTime) 
    {
      if (dict.Contains(date.DayOfWeek))
      {
         dict[date.DayOfWeek].Add(date);
      }
      else 
      {
         dict.Add(date.DayOfWeek, new List<Date> { date });
      }
    }
