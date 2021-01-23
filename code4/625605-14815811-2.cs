    // Test whether a sequence is strictly increasing.
    public bool IsIncreasing(IEnumerable<double> list)
    {
        bool initial = true;
    	double last = Double.MinValue;
    	foreach(var x in list)
    	{
    		if (!initial && x <= last)
    			return false;
    	
            initial = false;
    		last = x;
    	}
    	
    	return true;
    }
