    DateTime dt = DateTime.Now;
    DateTime conditionDateTime = 
            new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
    List<string> result = new List<string>();
    for (DateTime dt1 = new DateTime(dt.Year, dt.Month, 1); 
         dt1 <conditionDateTime; dt1 = dt1.AddDays(1))
    {
        result.Add(dt1.DayOfWeek.ToString());
    }
