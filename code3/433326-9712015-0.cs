    public void ApplyClientBehavior
        (ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    	CustomMessageInspector inspector = new CustomMessageInspector();
    	clientRuntime.MessageInspectors.Add(inspector);
    	clientRuntime.Via = new Uri("http://gatewayRouter/routingService");
    }
