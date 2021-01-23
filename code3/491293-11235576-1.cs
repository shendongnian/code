    static class Whatever
    {
        // oh, the horror....
    	public static string CreateWhitespace(uint spaces)
    	{			
    		var bldr = new StringBuilder();
    		for(int i = 0; i < spaces; ++i)
    		{
    			bldr.Append(" ");
    		}
    
    		return bldr.ToString();
    	}
    }
