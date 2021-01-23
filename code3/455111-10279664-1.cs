    void ReplaceFoosWithNumbers()
    {
    	int i;
    	Range c;
    	string firstAddress;
    	
    	Range rangeToSearchIn =  Worksheets(1).Range("a1:a5");
        Set c = rangeToSearchIn.Find("Foo", LookIn:=xlValues)
    	if (c != null) 
    	{
    		firstAddress = c.Address
    		while (true)
    		{
    			c.Value = i
    			i = i + 1
    			c = rangeToSearchIn.FindNext(c)
    			if (c == null)
    				break;
    		}
    	}
    }
