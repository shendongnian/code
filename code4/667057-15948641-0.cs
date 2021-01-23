    public void BlackOutDates(startDate, endDate, periodInDays)
    {
    	while(startDate < endDate)
    	{
    		calender.BlackoutDates.Add(new CalendarDateRange(startDate, startDate.AddDays(periodInDays));
    		startDate = startDate.AddDays(periodInDays+1);
    	}
    }
