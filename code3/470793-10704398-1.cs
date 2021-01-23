    DateTime end = DateTime.MaxValue;
    DateTime start = DateTime.MinValue;
    List<DateTime> datesIHave= new List<DateTime>();
    datesIHave.Add(DateTime.Now);
    List<DateTime> allDates = Enumerable.Range(0, 1 + end.Subtract(start).Days).Select(offset => start.AddDays(offset)).ToList();
    List<DateTime> blackoutDates = (from a in allDates 
                                    where !datesIHave.Contains(a)
                                    select a).ToList();
