    public ReadOnlyCollection<Friend> friendInstances { get; private set; }
    	
    public ReadOnlyBar(Bar bar)
    {
    	//other initialization
    	this.friendInstances = bar.friendInstances.ToList().AsReadOnly();
    }
