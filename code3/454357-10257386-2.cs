    public class RateLimitBehavior : IClientMessageInspector, IEndpointBehavior
    {
       public RateLimitBehavior(int maxRequestsPerSecond)
       {
           ...          
       }
       
       public object BeforeSendRequest(ref Message request, IClientChannel channel)
       {
           // Check to see if we're violating the total number of requests. 
           // As a suggestion have a class that contains:
           //   1. A counter
           //   2. A timer that counter every second
           //   3. A blocking method to check that counter < 80. If >80, keep checking.
           RateLimiter.Check();
           return null;
       }
       ...
       public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
       {
           clientRuntime.MessageInspectors.Add(this);
       }
    }
