    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
      if (endpointDispatcher != null)
      {
        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MessageInspector());
      }
    }
