    Task.Factory.StartNew (() =>
    {
    	Parallel.ForEach<string> (TextHelper.ReadLines(FileName), ProcessHelper.DefaultParallelOptions,
    	(string currentLine) =>
    	{
    		// Read line, validate and enqeue to an instance of FileLineData (custom class)
    	});
    }).
    ContinueWith 
    (
    	ic => isCompleted = true 
    );
    
    
    while (!isCompleted || qlines.Count > 0)
    {
    	if (qlines.TryDequeue (out returnLine))
    	{
    		yield return returnLine;
    	}
    }
