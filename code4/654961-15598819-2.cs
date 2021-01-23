    public IEnumerable<DayOfWeek> ConvertFromVisible(VisibleDayOfWeek visibleDay)
    {
    	if ((visibleDay & VisibleDayOfWeek.Monday) == VisibleDayOfWeek.Monday)
    		yield return DayOfWeek.Monday;
    	
    	if ((visibleDay & VisibleDayOfWeek.Tuesday) == VisibleDayOfWeek.Tuesday)
    		yield return DayOfWeek.Tuesday;
    		
    	if ((visibleDay & VisibleDayOfWeek.Wednesday) == VisibleDayOfWeek.Wednesday)
    		yield return DayOfWeek.Wednesday;
    		
    	if ((visibleDay & VisibleDayOfWeek.Thursday) == VisibleDayOfWeek.Thursday)
    		yield return DayOfWeek.Thursday;
    		
    	if ((visibleDay & VisibleDayOfWeek.Friday) == VisibleDayOfWeek.Friday)
    		yield return DayOfWeek.Friday;
    		
    	if ((visibleDay & VisibleDayOfWeek.Saturday) == VisibleDayOfWeek.Saturday)
    		yield return DayOfWeek.Saturday;
    		
    	if ((visibleDay & VisibleDayOfWeek.Sunday) == VisibleDayOfWeek.Sunday)
    		yield return DayOfWeek.Sunday;
    }
