    public event SampleEventHandle SampleEvent;
    protected virtual void OnSampleEvent()
    {
        var handler = SampleEvent;
        if (handler != null) 
            handler();
    }
    public delegate void SampleEventHandle();
    public void SampleMethod()
    {
        OnSampleEvent();
    }
}
