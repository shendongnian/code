    var now = DateTime.Now;
    var notAllowedDays = new[] { DayOfWeek.Friday, DayOfWeek.Saturday };
    var allowedHours = Enumerable.Range(10, 3).Concat(Enumerable.Range(20, 3));
    if(!notAllowedDays.Contains(now.DayOfWeek) && allowedHours.Contains(now.Hour))
    {
    
    } 
