        public bool Subscribe(GUID key)
        {
            try
            {
                if (Subscribers == null)
                {
                    Subscribers = new Dictionary<GUID, IAdvServiceCallback>();
                }
                lock (Subscribers)
                {
                    IServiceCallback callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                    if (!Subscribers.ContainsKey(key))
                    {
                        Subscribers.Add(key,callback);
                        ICommunicationObject obj = (ICommunicationObject)callback;
                        obj.Closed += SubscribedServiceClosed;
                        obj.Faulted += SubscribedServiceFaulted;
                    }
                    else
                    {
                        //log subscriber is registered
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UnSubscribe()
        {
            try
            {
                if (Subscribers == null)
                {
                    return true;
                }
                lock (Subscribers)
                {
                    IServiceCallback callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                    if (Subscribers.ContainsValue(callback))
                    {
                        var row = Subscribers.Where(v => v.Value == callback).FirstOrDefault();
                        Subscribers.Remove(row.Key);
                    }    
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
