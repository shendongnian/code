    public List<DateTime> getWeekdatesandDates(int Month, int Year)
    {
    	List<DateTime> weekdays = new List<DateTime>();
    	
    	var firstOfMonth = new DateTime(Year, Month, 1);
    	
    	var currentDay = firstOfMonth;
    	while (firstOfMonth.Month == currentDay.Month)
    	{
    		var dayOfWeek = currentDay.DayOfWeek;
    		if (dayOfWeek != DayOfWeek.Saturday && dayOfWeek != DayOfWeek.Sunday)
    			weekdays.Add(currentDay);
    		
    		currentDay = currentDay.AddDays(1);
    	}
    	
    	return weekdays;
    }
