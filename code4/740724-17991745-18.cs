    public static object ReturnSomething()
    {
    	foreach(var item in list)
    	{
    		try
    		{
    			return item;
    		}
    		finally
    		{
    			continue;
    		}
    	}
    }
