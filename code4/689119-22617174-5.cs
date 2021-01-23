    public class CustomDispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            return null;
        }
        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            var httpResponse = ((HttpResponseMessageProperty)reply.Properties["httpResponse"]);
            httpResponse.Headers.Add("user-agent", "My Browser");
        }
    }
