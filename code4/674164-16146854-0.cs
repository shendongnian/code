    private final List<MyObj> _allObjects = new List<MyObj>();
    ... // fill the _allObjects somewhere
    
    
    public IEnumerable<MyObj> AllGoodObjects 
    {
    	get { return from o in _allObjects 
    				 where o.IsGood
    				 select o; }
    }
    
    public IEnumerable<MyObj> AllBadObjects 
    {
    	get { return from o in _allObjects 
    				 where !o.IsGood
    				 select o; }
    }
