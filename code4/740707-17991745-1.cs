    public static void Exception()
    {
    	try
    	{
    		foreach(var item in list)
    		{
    			try
    			{
    				throw new Exception("What now?");
    			}
    			finally
    			{
    				continue;
    			}
    		}
    	}
    	catch
    	{
    		//do I get hit?
    	}
    }
