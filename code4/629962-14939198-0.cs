    static object _myLock;
    void myMethod ()
    {
    	if ( Monitor.TryEnter(_myLock) )
    	{
            try
            {
                // Do stuff
            }
            finally
            {
                Monitor.Exit(_myLock);
            }
    	}
    	else
    	{
    		// then I failed to get the lock.  Optionally do stuff.
    	}
    }
