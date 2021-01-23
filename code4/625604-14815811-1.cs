    // Test whether a sequence is strictly increasing.
    public bool IsIncreasing(IEnumerable<double> list)
    {
        bool first = true;
    	double last = Double.MinValue;
    	foreach(var x in list)
    	{
    		if (!first && x <= last)
    			return false;
    	
            first = false;
    		last = x;
    	}
    	
    	return true;
    }
