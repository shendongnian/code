    public class TestEvent
    {
    	private readonly ISubject<Unit> subject = new Subject<Unit>();
    	public IObservable<Unit> Events
    	{
    		get { return this.subject; }
    	}
    
    	public void ProcessEvents()
    	{
    		subject.OnNext(Unit.Default);
    	}
    }
    
    TestEvent te = new TestEvent();
    te.Events.Subscribe(_ => { Console.WriteLine("Received event"); });
