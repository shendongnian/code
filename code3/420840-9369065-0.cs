    private static readonly DayOfWeek[] weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
    
    bool IsWorkDay(DateTime day)//Encapsulate in a function, to simplify dealing with holydays
    {
    	return !weekends.Contains(day.DayOfWeek);
    }
    
    int WorkDaysLeftInMonth(DateTime currentDate)
    {
    	var remainingDates = Enumerable.Range(currentDate.Day,DateTime.DaysInMonth(currentDate.Year,currentDate.Month)-currentDate.Day+1)
    	                    .Select(day=>new DateTime(currentDate.Year, currentDate.Month, day));
    	return remainingDates.Count(IsWorkDay);
    }
