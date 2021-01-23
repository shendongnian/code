    catch(TaskCanceledException)
    {
    	if(!cts.Token.IsCancellationRequested)
    	{
    		// Timed Out
    	}
    	else
    	{
    		// Cancelled for some other reason
    	}
    }
