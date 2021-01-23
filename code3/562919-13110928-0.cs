    foreach(var command in commands)
    {
    	Task<int>.Factory.StartNew(ExecuteCommand)
    		.ContinueWith(
    			t => Invalidate(t.Result),
    			CancellationToken.None,
    			TaskContinuationOptions.PreferFairness,
    			TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    
    private void Invalidate(int heightMap)
    {
    	area.heightMap = eightMap;
    	glControl1.Invalidate();
    }
    
    private int ExecuteCommand()
    {
    	// returns new heightMap, because it's executes in non-UI thread
    	// you can't set UI control property
    	return Execute(area.heightMap, sim);
    }
