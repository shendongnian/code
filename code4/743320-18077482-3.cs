    public static List<Result> OperationB(CancellationToken token)
    {
    	var resultsList = new List<Result>();
    	while (true)
    	{               
    		foreach (var op in operations)
    		{
    			resultsList.Add(op.GetResult();
    		}
    		if (token.IsCancellationRequested)
    		{
    			return resultsList;
    		}
    	}
    }
