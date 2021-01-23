    class Z
        {
        public event EventHandler AfterMethodCalled;//defines a delegate to be used as an event. 
        
        protected virtual OnAfterMethodCalled
        {
        if(AfterMethodCalled!=null) //if there's at least one subscriber to this event
        AfterMethodCalled(this,EventArgs.Empty); //raise the event
        }
        
        public void Method()
        {
        //do the job
        OnAfterMethodCalled();
        }
    
    then each sub class can either subscribe to this event and even change the base behavior by overriding this virtual method:
    
    class A:
    {
    
    protected override OnAfterMethodCalled()
    {
    //do the job;
    base.OnAfterMethodCalled(); // you can omit this line if you want to prevent raising the event
    }
    }
        }
