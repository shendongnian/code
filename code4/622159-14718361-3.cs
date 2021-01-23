    private static Dictionary<Type, Delegate> handlers;
    
    static HandlerClass()
    {
    	handlers = new Dictionary<Type, Delegate>();
    	AddHandler<EventSubClassA>(HandleEventSubClassA);
    	AddHandler<EventSubClassB>(HandleEventSubClassB);
    	...
    }
    
    public static void AddHandler<T>(Action<T> handler) where T : EventClassA
    {
    	handlers[typeof(T)] = handler;
    }
    
    public void HandleEvent(EventClassA @event)
    {
    	Delegate handler;
    	if(handlers.TryGetValue(@event.GetType(), out handler))
    	{
    		handler.DynamicInvoke(@event);
    	}
    }
