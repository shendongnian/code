    public void DoWork(CancellationToken cancelToken)
    {
    	try
    	{
    		//do work
    		cancelToken.ThrowIfCancellationRequested();
    		//more work
    	}
    	catch (OperationCanceledException) when (cancelToken.IsCancellationRequested)
    	{
    		// ignored
    	}
    	catch (Exception ex)
    	{
    		Log.Exception(ex);
    		throw;
    	}
    }
