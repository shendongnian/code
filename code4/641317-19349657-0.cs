    class DidRun
    {
    	public bool Value { get; set; }
    }
    
    class TestEventPublisher
    {
    	public event EventHandler<EventArgs> MyEvent;
    	public void RaiseMyEvent()
    	{
    		if (MyEvent != null)
    			MyEvent(this, EventArgs.Empty);
    	}
    }
    
    class TestClosure
    {
    	static public EventHandler<EventArgs> Register(TestEventPublisher raiser, DidRun didrun)
    	{
    		EventHandler<EventArgs> handler = (s, e) => didrun.Value = true;
    		WeakEventManager<TestEventPublisher, EventArgs>.AddHandler(raiser, "MyEvent", handler);
    		return handler;
    	}
    }
    
    [TestMethod]
    public void Test1()
    {
    	var raiser = new TestEventPublisher();
    	var didrun = new DidRun();
    	
    	TestClosure.Register(raiser, didrun);
    	
    	// The reference to the closure 'handler' is not being held,
    	//  it may or may not be GC'd (indeterminent result)
    	
    	raiser.RaiseMyEvent();
    	Assert.IsTrue(didrun.Value);
    }
    
    [TestMethod]
    public void Test2()
    {
    	var raiser = new TestEventPublisher();
    	var didrun = new DidRun();
    	
    	// The reference to the closure 'handler' is not being held, it's GC'd
    	TestClosure.Register(raiser, didrun);
    
    	GC.Collect();
        GC.Collect();
    	
    	raiser.RaiseMyEvent();
    	Assert.IsFalse(didrun.Value);
    }
    
    [TestMethod]
    public void Test3()
    {
    	var raiser = new TestEventPublisher();
    	var didrun = new DidRun();
    	
    	// Keep local copy of handler to prevent it from being GC'd
    	var handler = TestClosure.Register(raiser, didrun);
    
    	GC.Collect();
        GC.Collect();
    	
    	raiser.RaiseMyEvent();
    	Assert.IsTrue(didrun.Value);
    }
