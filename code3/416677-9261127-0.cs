    public class Foo : IDisposable
    {
    	private event EventHandler MyEvent;
     	private readonly IDisposable _subscription;
    	
    	public Foo()
    	{
    		var subs = Observable.FromEventPattern(
    			e => MyEvent += e, 
    			e => MyEvent -= e);
     
    		// (1) foo is never GC'd
    		//subs.Window(TimeSpan.FromSeconds(1)).Subscribe();
    		_subscription = subs.Window(TimeSpan.FromSeconds(1)).Subscribe();
     
    		// (2) foo is GC'd
    		//subs.Window(TimeSpan.FromSeconds(1));
     
    		// (3) foo is GC'd
    		// subs.Window(1);
    	}
     
     	public void Dispose()
    	{
    		_subscription.Dispose(); 
    	}
     
     	//TODO: Implement Dispose pattern properly
    	~Foo()
    	{
    		_subscription.Dispose();
    		Console.WriteLine("Bye!");     
    	}
    }
