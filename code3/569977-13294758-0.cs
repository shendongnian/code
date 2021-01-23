    BlockingCollection<int> _queue = new BlockingCollection<int>(BufferSize);
    
    void Init()
    {
	    Task.Factory.StartNew(PopulateIdBuffer, TaskCreationOptions.LongRunning);
    }
    void PopulateIdBuffer()
    {
    	int id = 0;
    	while (true)
    	{
    		Thread.Sleep(1000); //Simulate long retrieval
    		_queue.Add(id++);
    	}
    }
    void SomeMethodThatNeedsId()
    {
        var nextId = _queue.Take();
        ....
    }
