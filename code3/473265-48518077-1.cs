            public class CustomHeaderMessageInspector : IDispatchMessageInspector
            {
                Dictionary<string, string> requiredHeaders;
                public CustomHeaderMessageInspector (Dictionary<string, string> headers)
                {
                    requiredHeaders = headers ?? new Dictionary<string, string>();
                }
                public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
                {
                    return null;
                }
                public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
                {
                    var httpHeader = reply.Properties["httpResponse"] as HttpResponseMessageProperty;
                    foreach (var item in requiredHeaders)
                    {
                        httpHeader.Headers.Add(item.Key, item.Value);
                    }           
                }
            }
