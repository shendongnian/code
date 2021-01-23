    [Flags]
    public enum State
    {
    	Important = 1,
    	Updated = 2,
    	Deleted = 4,
    	XXX = 8
    	....
    }
    
    public class Content
    {
    	public State MyState { get; set; }
    }
    
    if ((myContent.MyState & State.Important) == State.Important
    	&& (myContent.MyState & State.Updated) == State.Updated)
    {
    	// Important AND updated
    }
