    public class RateLimitBehavior : IClientMessageInspector, IEndpointBehavior
    {
       public object BeforeSendRequest(ref Message request, IClientChannel channel)
       {
           // Check to see if we're violating the total number of requests
           // If we are then sleep 
           return null;
       }
       ...
       public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
       {
           clientRuntime.MessageInspectors.Add(this);
       }
    }
