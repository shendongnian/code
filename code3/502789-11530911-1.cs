        public class SampleMessageInspector : IDispatchMessageInspector
    {             
        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var objectToDispose = ServiceLocator.Current.GetInstance<ObjectToDispose>();
            //do your work
            return null;
        }
        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //do some other work
        }
    }
