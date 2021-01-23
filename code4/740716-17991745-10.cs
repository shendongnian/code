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
    			
    			}
    		}
    		finally
    		{
    			if (someCondition)
    				return someValue;
    			else
    				//no exception will be thrown, 
    				//so theoretically this could work
    				continue;
    		}
    	}
    }
