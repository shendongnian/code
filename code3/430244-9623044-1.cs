    public class MyClass
    {    
    	// Could be anything...
    	public delegate void MyEventHandler(object sender, EventArgs e);
    
    	public event MyEventHandler TestEvent;
    
    	public void Test()
    	{
    		if (this.TestEvent != null)
    		{
    			this.TestEvent(this, EventArgs.Empty);
    		}
    	}
    }
    
    public class EventManager
    {
    	private List<EventHandler> Handlers = new List<EventHandler>();
    
    	public void AddHandler(EventHandler handler)
    	{
    		this.Handlers.Add(handler);
    	}
    
    	public void RemoveHandler(EventHandler handler)
    	{
    		this.Handlers.Remove(handler);
    	}
    
    	public void Handler(object sender, EventArgs e)
    	{
    		foreach (var z in this.Handlers)
    		{
    			z.Invoke(sender, e);
    		}
    	}
    }
    
    private static void Main(string[] args)
    {
    	MyClass test = new MyClass();
    
    	EventManager eventManager = new EventManager();
        // Subscribes to the event
        test.TestEvent += eventManager.Handler;
        // Adds two handlers in a known order
    	eventManager.AddHandler(Handler1);
    	eventManager.AddHandler(Handler2);
    
    	test.Test();
    
    	Console.ReadKey();
    }
    
    private static void Handler1(object sender, EventArgs e)
    {
    	Console.WriteLine("1");
    }
    
    private static void Handler2(object sender, EventArgs e)
    {
    	Console.WriteLine("2");
    }
