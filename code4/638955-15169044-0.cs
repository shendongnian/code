       private ServerManager _defaultManager = new ServerManager();
        
       public void AddSite()
       {
            // perform task
            _defaultManager.CommitChanges();            
        }
        
        public void RemoveSite()
        {
            // perform task
            _defaultManager.CommitChanges();
        }
        public void Dispose() {
           _defaultManager.Dispose();
        }
