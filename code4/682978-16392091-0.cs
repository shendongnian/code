    public static class PrestoWcf
    {
        public static IEnumerable<Application> PrestoService
        {
            get
            {
                IEnumerable<Application> appList;
                using (var channelFactory = new WcfChannelFactory<IPrestoService>(new NetTcpBinding()))
                {
                    var endpointAddress = ConfigurationManager.AppSettings["prestoServiceAddress"];    
                    appList = prestoService.GetAllApplications().ToArray(); //you can ignore the .ToArray, I just not sure whether the enumerable still keep the reference to service
                }
                return appList;
            }
        }
    }
