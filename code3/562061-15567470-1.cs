    Class MyProxyInspector:IClientMessageInspector
    {
        public static string MyParam;
         
        ...
        
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            request.Headers.Add(MessageHeader.CreateHeader(headerName, headerNamespace, MyParam));
            return null;
        }
    } 
