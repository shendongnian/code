    ThreadTheClass T;
    
     protected override void OnStart(string[] args)
        {
            T = new ThreadTheClass();
    
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }
                T.ThreadMain();
    
                serviceHost = new ServiceHost(typeof(ProjectWCF.WCFService));
                serviceHost.Open(); 
        }
    
        protected override void OnStop()
        {
                if (serviceHost != null)
                {
                    WCFWindowsService ThreadPost = new WCFWindowsService();
    
                    T.ThreadStop();
    
    
                    serviceHost.Close();
                    serviceHost = null;
                }
        }
