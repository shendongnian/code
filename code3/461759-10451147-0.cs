        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            using (ServiceHost serviceHost = new ServiceHost(typeof(myService)))
            {
                serviceHost.Open();
            }
        }
