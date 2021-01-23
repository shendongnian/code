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
    		throw;
    	}
    	catch (Exception ex)
    	{
    		Log.Exception(ex);
    		throw;
    	}
    }
