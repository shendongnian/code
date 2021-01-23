    /// <summary>
    /// WCF Message dispatcher.
    /// </summary>
    public class DispatchMessageInspector : IDispatchMessageInspector
    {
    	public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
    		// Write your code here.
            return null;
        }
    
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
    		// Write your code here.
        }
    }
    
