    public static object SafeMethod()
    {
    	foreach(var item in list)
    	{
    		try
    		{
    			try
    			{
    				//do something that won't transfer control outside
    			}
    			catch
    			{
    				//catch everything to not throw exceptions
    			}
    		}
    		finally
    		{
    			if (someCondition)
    				//no exception will be thrown, 
    				//so theoretically this could work
    				continue;
    		}
    	}
        return someValue;
    }
