    public static bool IsClearTypeEnabled
    {
    	get
    	{
    		try
    		{
    			return SystemInformation.FontSmoothingType == 2;
    		}
    		catch //NotSupportedException
    		{
    			return false;
    		}
    	}
    }
