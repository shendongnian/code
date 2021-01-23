    public static void Goto()
    {
    	foreach(var item in list)
    	{
    		try
    		{
    			goto pigsfly;
    		}
    		finally
    		{
    			continue;
    		}
    	}
    	
    	pigsfly:
    }
