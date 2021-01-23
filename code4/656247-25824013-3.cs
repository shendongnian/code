    public class MyMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Console.WriteLine("Incoming request: {0}", request);
            return null;
        }
    
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
    
    public class MyEndPointBehavior : IEndpointBehavior
    {
        #region IEndpointBehavior Members
    
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            ChannelDispatcher channelDispatcher = endpointDispatcher.ChannelDispatcher;
            if (channelDispatcher != null)
            {
                foreach (EndpointDispatcher ed in channelDispatcher.Endpoints)
                {
                    ed.DispatchRuntime.MessageInspectors.Add(new MyMessageInspector());
                }
            }
        }
    
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    
        #endregion
    }
