    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class MyService : IMyService
    {
        private List<IMyService_Callback> callbacks;
        public MyService()
        {
            // Initialise callbacks
            this.callbacks = new List<IMyService_Callback>();
        }
        public bool Subscribe()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMyService_Callback>();
            if (!callbacks.Contains(callback))
                callbacks.Add(callback);
            }
            
            return true;
        }
        private void CallClients(string message)
        {
            // Execute the callbacks
            callbacks.ForEach(delegate(IMyService_Callback callback)
            {
                callback.NotifyClient(message);
            });
        }
    }
