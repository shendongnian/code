    // Event types to raise.
    enum EventType { Action, Cancel };
    
    // Base abstract class to use in the generic type field
    abstract class BaseEvent
    {
    	public double time;
    
    	protected BaseEvent(double _time)
    	{
    		time = _time;
    	}
    }
    
    // Event delegate, T is a sub of BaseEvent that contains the data we need to send
    delegate void EventDelegate<T>(T eventClass) where T : BaseEvent;
    
    // Event class
    static class EventSystem
    {
    	// EventClass is the storage of all the generic types and their mapping to an event delegate.
    	private static class EventClass<T> where T : BaseEvent
    	{
    		public static Dictionary<EventType, EventDelegate<T>> eventMapping = new Dictionary<EventType, EventDelegate<T>>();
    	}
    
    	/// <summary>
    	/// Hooks an event to a delegate for use with EventSystem.RaiseEvent
    	/// </summary>
    	/// <typeparam name="T">Sub-class of BaseEvent that your delegate will be receiving</typeparam>
    	/// <param name="eventType">Type of event to hook to</param>
    	/// <param name="_event">The callback</param>
    	public static void HookEvent<T>(EventType eventType, EventDelegate<T> _event) where T : BaseEvent
    	{
    		if (EventClass<T>.eventMapping.ContainsKey(eventType))
    		{
    			EventClass<T>.eventMapping[eventType] += _event;
    		}
    		else
    		{
    			EventClass<T>.eventMapping.Add(eventType, _event);
    		}
    	}
    
    	/// <summary>
    	/// Raises an event and calls any callbacks that have been hooked via HookEvent
    	/// </summary>
    	/// <typeparam name="T">The sub-class of BaseEvent you are sending</typeparam>
    	/// <param name="eventType">Type of event you are raising</param>
    	/// <param name="args">A subclass of BaseEvent containing the information to pass on</param>
    	public static void RaiseEvent<T>(EventType eventType, T args) where T : BaseEvent
    	{
    		if (EventClass<T>.eventMapping.ContainsKey(eventType))
    		{
    			EventClass<T>.eventMapping[eventType].Invoke(args);
    		}
    		else
    		{
    			// do nothing
    		}
    	}
    }
