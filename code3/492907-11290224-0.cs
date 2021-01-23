    class YearMonthCount
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }
    }
    
    // Start and End dates
    DateTime startDate = new DateTime(2011, 9, 1);
    DateTime endDate = new DateTime(2012, 6, 1);
    // this would be a sample of the QueryOver() result
    List<YearMonthCount> result = new List<YearMonthCount>();
    result.Add(new YearMonthCount { Year = 2011, Month = 10, Count = 2 });
    result.Add(new YearMonthCount { Year = 2011, Month = 11, Count = 3 });
    result.Add(new YearMonthCount { Year = 2012, Month = 1, Count = 4 });
    result.Add(new YearMonthCount { Year = 2012, Month = 2, Count = 1 });
    result.Add(new YearMonthCount { Year = 2012, Month = 4, Count = 1 });
    result.Add(new YearMonthCount { Year = 2012, Month = 5, Count = 1 });
    
    int i = 0;
    List<YearMonthCount> result2 = new List<YearMonthCount>();
    // iterate through result list, add any missing entry
    while (startDate <= endDate)
    {
    	bool addNewEntry = true;
    	// check to avoid OutOfBoundsException
    	if (i < result.Count)
    	{
    		DateTime listDate = new DateTime(result[i].Year, result[i].Month, 1);
    		if (startDate == listDate)
    		{
    			// entry is in the QueryOver result -> add this
    			result2.Add(result[i]);
    			i++;
    			addNewEntry = false;
    		}
    	}
    	if (addNewEntry)
    	{
    		// entry is not in the QueryOver result -> add a new entry
    		result2.Add(new YearMonthCount { 
    			Year = startDate.Year, Month = startDate.Month, Count = 0 });
    	}
    	startDate = startDate.AddMonths(1);
    }
