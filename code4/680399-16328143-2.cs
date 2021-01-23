      private SynchronizationContext _appSyncContext = null;
      private DTOCommunicationsService()
        {
            this.AppSyncContext = SynchronizationContext.Current;
            //Sets up the service proxy, etc, etc
            Open();
        }
      // Callback method
        public void ClientSubscriptionNotification(string clientID, SubscriptionState subscriptionState)
        {
            SendOrPostCallback callback = delegate(object state)
            {
                object[] inputArgs = (object[])state;
                string argClientID = (string)inputArgs[0];
                SubscriptionState argSubState = (SubscriptionState)inputArgs[1];
                //Do stuff with arguments
            };
            _appSyncContext.Post(callback, new object[] { clientID, subscriptionState });
        }
