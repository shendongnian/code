    public Task<double> GetTask()
    {
        var rootTask = new Task<int>((() => 10));
    	var continuationTask = rootTask
    		.ContinueWith(i =>
    		{
    			return i.Result + 2;
    		})
    		.ContinueWith(i =>
    		{
    			return (double)i.Result;
    		});
        rootTask.Start(),
        return continuationTask;
    }
