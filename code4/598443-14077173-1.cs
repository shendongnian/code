    object GetCachedValue(string Key)
    {
        // note here that I use the key as the name of the mutex
        // also here you need to check that the key have no invalid charater
        //   to used as mutex name.
        var mut = new Mutex(true, key);
    
        try
        {   
            // Wait until it is safe to enter.
            mut.WaitOne();
    
            // here you create your cache
    	    if (!Cache.ContainsKey(Key))
    		{
    			 //long running operation to fetch the value for id
    			 object value = GetTheValueForId(Key);
    			 Cache.Add(Key, value);
    		}     
    		
    		return Cache[Key];        
        }
        finally
        {
            // Release the Mutex.
            mut.ReleaseMutex();
        }   
    }
