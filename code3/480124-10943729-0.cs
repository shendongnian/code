    public void TestConnection()
    {
        var wf = new WebChannelFactory<IOtherService>(otherURI);
        var service = wf.CreateChannel();
        using ((IDisposable)service)
        using (new OperationContextScope((IContextChannel)service))
        {
          service.Test();
        }
    }
