    public static T GetByIndexOrDefault<T>(this Array array, int index)
    {
    	if (array == null)
    	{
    		return default(T);
    	}
    
    	if (index <= array.Length)
    	{
    		return (T)array.GetValue(index - 1);
    	}
    
    	return default(T);
    }
