        public void Stop(bool immediate)
        {
            if (!immediate && _working)
                return;//don't unregister yet, give it some time
            
            if(immediate && _working)
            {
                //TODO: Log this instance
            }
            HostingEnvironment.UnregisterObject(this);
        }
