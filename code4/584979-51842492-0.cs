    List<DateTime> DivideTimeRangeIntoIntervals(DateTime startTS, DateTime endTS, int numberOfIntervals)
    {
    	long startTSInTicks = startTS.Ticks;
    	long endTsInTicks = endTS.Ticks;
    	long tickSpan = endTS.Ticks - startTS.Ticks;
    	long tickInterval = tickSpan / numberOfIntervals;
    
    	List<DateTime> listOfDates = new List<DateTime>();
    	for (long i = startTSInTicks; i <= endTsInTicks; i += tickInterval)
    	{
    		listOfDates.Add(new DateTime(i));
    	}
    	return listOfDates;
    }
