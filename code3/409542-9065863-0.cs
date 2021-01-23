    public event EventHandler RaiseCustomEvent;
         
    public void DoSomething()
    {
        OnRaiseCustomEvent();
    }
    
    protected virtual void OnRaiseCustomEvent()
    {
        EventHandler handler = RaiseCustomEvent;
    
        if (handler != null)
        {
             handler(this);
        }
    }
