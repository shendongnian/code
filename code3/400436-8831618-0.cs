    using(var reader = GetStreamReader())
    {
    	bool justReadATag = false;
    	string line = string.Empty;
    
    	while((line = reader.ReadLine()) != null)
    	{
    		if(IsTag(line)) 
    		{
    			// do some work with the paragraph tag
    			justReadATag = true;
    		}else{
    			string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    			if(justReadATag) 
    			{
    				// do some work with the column names
    				justReadATag = false;	 
    			}else
    			{
    				// do some work with the cell values
    			}
    		}
    	}
    }
