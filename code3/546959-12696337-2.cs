    public int FirstHeight
    {
    	get
    	{
    		int returnValue; // Or some other default value you can check against.
    		
    		if (!int.TryParse(textBox2.Text, out returnValue))
    		{
    			// If the call goes in here, the text from the input is not convertable to an int.
    			// returnValue should be set to 0 when int.TryParse fails.
    		}
    		
    		return returnValue;
    	}
    }
