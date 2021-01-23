    public event EventHandler MyEvent;
    protected void RaiseMyEvent()
    {
        var myEvent = MyEvent;
        if (myEvent != null)
           MyEvent(EventArgs.Empty);
    }
 
