    private Queue<Action> ActionQueue = new Queue<Action>();
    private object LockObj = new Object();
    private bool IsRunning;
    private ManualResetEvent Start = new ManualResetEvent(false);
    
    public void HandleEvent(object sender, EventArgs e)
    {
        bool started = false;
    	lock(this.LockObj)
    	{
    		this.ActionQueue.Enque(() => this.Handle(sender, e));
    
    		if (!this.IsRunning)
    		{
    			Task.Factory.StartNew( this.Loop() );
                        started = true;
    		}
    	}
        if (started)
           this.Start.Set();
    }
    
    private void Loop
    {
    	this.Start.WaitOne();
    	
    	while ((Action action = this.DequeueAction()) != null)
    		action();
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
