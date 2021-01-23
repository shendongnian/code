    public interface IHandlers
    {
    	void HandleSubClassA(EventSubClassA a);
    	void HandleSubClassB(EventSubClassB b);
        ...
    }
    
    public abstract class EventClassA
    {
    	public abstract void Visit(IHandlers handlers);
    }
    
    public class EventSubClassA : EventClassA
    {
    	public override void Visit(IHandlers handlers)
    	{
    		handlers.HandleSubClassA(this);
    	}
    }
