    MyServiceClient clientService;
    AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    public void Execute()
    {
        InvokeCompletedEventArgs data = null;
        clientService.InvokeCompleted += (e, f) =>
        {
            data = f;
            autoResetEvent.Set();
        };
        m_proxy.MyCallAync();
        autoResetEvent.WaitOne(); // Wait the set of autoResetEvent
        m_proxy.MySecondCallAync(data); // Data return by the first call
    }
