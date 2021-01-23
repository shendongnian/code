    //inclusive start and inclusive end
    public IEnumerable<DateTime> DateSequence(DateTime start, TimeSpan interval, DateTime end)
    {
    	DateTime current = start;
    	while(current <= end)
    	{
    		yield return current;
    		current = current.Add(interval);
    	}
    }
