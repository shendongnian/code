    void Main()
    {
    	var starttime = DateTime.Now;
    	for (var i = 0; i < 1000000000; i++)
    	{
    		if (ValidateRequest()) continue;
    	}
    	var endtime = DateTime.Now;
    	Console.WriteLine(endtime.Subtract(starttime));
    
    	starttime = DateTime.Now;
    	for (var i = 0; i < 100000000; i++)
    	{
    		if (_doc != null) continue;
    	}
    	endtime = DateTime.Now;
    	Console.WriteLine(endtime.Subtract(starttime));
    }
    
    private object _doc = null;
    
    private bool ValidateRequest()
    	{
    		return _doc != null;
    	}
