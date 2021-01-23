    System.ServiceModel.ServiceActivationException: The requested service, 'XXX' could not be activated. See the server's diagnostic trace logs for more information.
    Server stack trace: 
       at System.ServiceModel.Channels.HttpChannelUtilities.ValidateRequestReplyResponse(HttpWebRequest request, HttpWebResponse response, HttpChannelFactory`1 factory, WebException responseException, ChannelBinding channelBinding)
       at System.ServiceModel.Channels.HttpChannelFactory`1.HttpRequestChannel.HttpChannelRequest.WaitForReply(TimeSpan timeout)
       at System.ServiceModel.Channels.RequestChannel.Request(Message message, TimeSpan timeout)
       at System.ServiceModel.Channels.ServiceChannel.Call(String action, Boolean oneway, ProxyOperationRuntime operation, Object[] ins, Object[] outs, TimeSpan timeout)
       at System.ServiceModel.Channels.ServiceChannelProxy.InvokeService(IMethodCallMessage methodCall, ProxyOperationRuntime operation)
       at System.ServiceModel.Channels.ServiceChannelProxy.Invoke(IMessage message)
