    private Queue<Action> ActionQueue = new Queue<Action>();
    private object LockObj = new Object();
    private volatile bool IsRunning;
    
    public void Attach(Class1 obj)
    {
       obj.SomeEvent += this.HandleEvent;
    }
    private void HandleEvent(object sender, EventArgs e)
    {
    	lock(this.LockObj)
    	{
    		this.ActionQueue.Enque(() => this.Handle(sender, e));
    
    		if (!this.IsRunning)
    		{
			   Task.Factory.StartNew(() => this.Loop() );
    		}
    	}
    }
    
    private void Loop()
    {
        this.IsRunning = true;
    	while ((Action action = this.DequeueAction()) != null)
    		action();
        this.IsRunning = false;
    }
    
    private Action DequeueAction()
    {
    	lock (this.LockObj)
    	{
    		return this.ActionQueue.Count > 0 ? this.ActionQueue.Dequeue() : null;
    	}
    }
    
    private void Handle(object sender, EventArgs e)
    {
    //handling code
    }
