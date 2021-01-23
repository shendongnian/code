    public static void UsePrestoService(Action<IPrestoService> callback)
    {
        using (var channelFactory = new WcfChannelFactory<IPrestoService>(new NetTcpBinding()))
        {
            var endpointAddress = ConfigurationManager.AppSettings["prestoServiceAddress"];
            IPrestoService prestoService = channelFactory.CreateChannel(new EndpointAddress(endpointAddress));  
            //Now you have access to the service before the channel factory is disposed.  But you don't have to worry about disposing the channel factory.
            callback(prestoService);
        }
    }
    UsePrestoService(service => this.Applications = new ObservableCollection<Application>(service.GetAllApplications().ToList()));
