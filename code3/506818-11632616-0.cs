    var start = new DateTime(2012, 8, 17);
    var end = new DateTime(2012, 9, 17);
    
    var daysToChoose = new DayOfWeek[] { DayOfWeek.Thursday, DayOfWeek.Tuesday };
    
    var dates = Enumerable.Range(0, (int)(end - start).TotalDays + 1)
                            .Select(d => start.AddDays(d))
                            .Where(d => daysToChoose.Contains(d.DayOfWeek));
