    public class CustomInstanceProvider:IInstanceProvider
    {
    
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }
    
        public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return new DLSService.DLSService();
        }
            
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {            
        }
    }
    
    var mServiceHost = new ServiceHost(typeof(DLSService.DLSService), new Uri("http://localhost:8000/DLS"));   
    mServiceHost.AddServiceEndpoint(typeof(DLSService.IDLSService), new BasicHttpBinding(), "ServicesHost");
    
    foreach (var channelDispatcher in mServiceHost.ChannelDispatchers.OfType<ChannelDispatcher>())
    {
        foreach (var endpointDispatcher in channelDispatcher.Endpoints)
        {
            endpointDispatcher.DispatchRuntime.InstanceProvider = new CustomInstanceProvider();
        }
    }
    mServiceHost.Open();
