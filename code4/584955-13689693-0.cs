    return task.ContinueWith(t =>
    {
    	if (t.IsFaulted)
    	{
    		//handle error
    		Exception firstException = t.Exception.InnerExceptions.First();
    	}
    	else
    	{
    		return FinishWebRequest(t.Result);
    	}
    });
