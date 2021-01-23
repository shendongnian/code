    public static int CompareStringByInteger(string x, string y)
    {
    	if (x == null)
    	{
    		if (y == null)
    			return 0;
    		else
    				return -1;
    	}
    	else
    	{
    		try{
    			return Convert.ToInt32(x).CompareTo(Convert.ToInt32(y));
    		}catch{
    			return x.CompareTo(y);
    		}
    	}
    }
