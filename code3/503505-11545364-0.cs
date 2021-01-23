    //... Class Impl
    
    private string keys = String.Empty;
    private readonly TimeSpan bufferDelay = new TimeSpan(100000);
    private DateTime lastKeyPress = DateTime.UtcNow;
    
    private void DoSomething(string text)
    {
    //do something to process text.
        keys = String.Empty;
    
    }
    
    
    public void DoSomethingBuffer(string text)
    {
        keys =+ text;
        var now = DateTime.UtcNow;
        if((now-lastKeyPress) > bufferDelay)
    {
        DoSomething(keys);
    }
        lastKeyPress = now;
    
    }
    //... More Class Impl
