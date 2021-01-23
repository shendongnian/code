    public void SetOptions<T>()
    {
    	Type genericType = typeof(T);
    	if (genericType.IsEnum)
    	{
    		foreach (T obj in Enum.GetValues(genericType))
    		{
    			Enum test = Enum.Parse(typeof(T), obj.ToString()) as Enum;
    			int x = Convert.ToInt32(test); // x is the integer value of enum
                            ..........
                            ..........
    		}
    	}
    }
