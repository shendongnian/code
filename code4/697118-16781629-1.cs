    //Process 1
    //High frequency "writes"
    
    //Wait to allow writing
    if (event.WaitOne(System.Threading.Timeout.Infinite))
    {
    	try
    	{
    	    mutex.WaitOne(System.Threading.Timeout.Infinite);
    
    	    try
    	    {
    	        //Do write operation
    
    	    }
    	    finally
    	    {
    	        mutex.ReleaseMutex();
    	    }
    	}
    	catch(AbandonedMutexException)
    	{
    	    //Log error
    	}
    }
