    private static Object settingValue = new Object();
    static void InsertRange(int index)
    {
    	// This part can be executed in parallel.
    	List<int> values = Enumerable.Range(0, 7205).ToList();
    
    	lock (settingValue)
    	{
    		allLists[index] = values;
    	}
    }
