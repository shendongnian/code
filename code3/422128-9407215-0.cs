    public event Action MyEvent;
    
    public void MyMethod()
    {
        // a lot of work...
    
        SomethingHappened();
    }
    
    protected virtual void SomethingHappened()
    {
        Action currentEvent = MyEvent;
    
        if (currentEvent != null)
        {
            currentEvent();
        }
    }
