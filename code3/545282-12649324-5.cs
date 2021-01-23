    public static class MyExtensions
    {
    	public static void Fire<TSender, TEventArgs>(this DataEventHandler<TSender, TEventArgs> eventHandler, TSender sender, TEventArgs args)
    	{
    		if (eventHandler!= null)
    			eventHandler(sender, args);
    	}
    
    	public static void Fire<TEventArgs>(this DataEventHandler<TEventArgs> eventHandler, TEventArgs args)
    	{
    		if (eventHandler != null)
    			eventHandler(args);
    	}
    }
