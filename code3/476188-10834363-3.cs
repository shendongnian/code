    public class BaseEvent
    {
    	public BaseEvent(EventType type)
    	{
    		Event = type;
    	}
    
    	EventType Event { get; set; }
    	DateTime EventDate ....
    }
