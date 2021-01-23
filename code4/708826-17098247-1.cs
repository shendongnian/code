    using (Mutex applicationMutex = new Mutex(true, "SomeRandomTextHere", out mutexCreated))
    {
    	if (!mutexCreated)
    	{
    		// Application is already running. Aborting..
    		return;
    	}
        // Application.Run(..)  goes here, plus other interesting stuff
    }
