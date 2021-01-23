    public static List<string> EmptySList()
    {
    	return EmptyList<string>();
    }
    
    public static List<T> EmptyList<T>()
    {
    	return new List<T>();
    }
    
    ...
    
    List<string> Columns = EmptySList(), Parameters = EmptySList(), Values = EmptySList();
