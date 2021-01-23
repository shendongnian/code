    void MethodA()
    {
         foreach (var obj in objects)
             if (obj != this)
                 Monitor.Enter(obj);
    
    try
    {
    	// do stuff
    }
    finally
    {
            foreach( var obj in objects)
            if (obj != this)
                     Monitor.Exit(obj);
    }	
    }
