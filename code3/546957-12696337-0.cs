    public int? FirstHeight
    {
    	get
    	{
    		int? returnValue = null;
    		
    		int temp;
    		if (int.TryParse(textBox2.Text, out temp))
    		{
    			returnValue = temp;
    		}
    		
    		return returnValue;
    	}
    }
