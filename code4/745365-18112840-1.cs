    partial class RemoteArchiveService : ServiceBase
    {
        // ...
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(RemoteArchiveWCFService));
            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }
        // ...
    }
