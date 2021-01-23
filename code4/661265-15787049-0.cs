    Dictionary<DateTime, bool> dates = new Dictionary<DateTime, bool>()
    {
    	{
    		DateTime.Now, true
    	}
    };
    
    var modifiedDic = dates.ToDictionary(z => z.Key.AddDays(-1), z => z.Value);
