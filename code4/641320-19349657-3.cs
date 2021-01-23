    // ConditionalWeakTable will hold the 'value' as long as the 'key' is not marked for GC
    static private ConditionalWeakTable<INotifyPropertyChanged, EventHandler<PropertyChangedEventArgs>> _eventMapping =
      new ConditionalWeakTable<INotifyPropertyChanged, EventHandler<PropertyChangedEventArgs>>();
    		
    public static void AddWeakPropertyChanged(this INotifyPropertyChanged item, Action<string> handlerAction)
    {
    	EventHandler<PropertyChangedEventArgs> handler;
    	
    	// Remove any existing handler for this item in case it's registered more than once
    	if (_eventMapping.TryGetValue(item, out handler))
    	{	
    		_eventMapping.Remove(item);
    		PropertyChangedEventManager.RemoveHandler(item, handler, string.Empty);
    	}	
    	
    	handler = (s, e) => handlerAction(e.PropertyName);
    	
    	// Save handler (closure) to prevent GC
    	_eventMapping.Add(item, handler);
    	
    	PropertyChangedEventManager.AddHandler(item, handler, string.Empty);
    }
    
    class DidRun
    {
    	static public string Value { get; private set; }
    	public void SetValue(string value) { Value = value; }
    }
    
    [TestMethod]
    public void Test4()
    {
    	var property = new ObservableObject<string>();
    	
        var didrun = new DidRun();
    	property.AddWeakPropertyChanged(
    		(x) => 
    		{
    			didrun.SetValue("Property Name = " + x);
    		});
        GC.Collect();
        GC.Collect();
    	
    	property.Value = "Hello World";
    	
    	Assert.IsTrue(DidRun.Value != null);
    }
