    DateTime end = DateTime.Now;
    DateTime start = end.AddDays(-100);
    DayOfWeek[] weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
    
    var count = Enumerable.Range(0, Convert.ToInt32(end.Subtract(start).TotalHours))
         .Count(offset => !weekend.Contains(start.AddHours(offset).DayOfWeek));
