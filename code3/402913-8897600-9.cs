    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class MyService : IMyService
    {
        private List<IMyService_Callback> callbacks;
        public MyService()
        {
            this.callbacks = new List<IMyService_Callback>();
        }
        private void CallClients(string message)
        {
            callbacks.ForEach(delegate(IMyService_Callback callback)
            {
                callback.NotifyClients(message);
            });
        }
        public bool Subscribe()
        {
            IMyService_Callback callback = OperationContext.Current.GetCallbackChannel<IMyService_Callback>();
            if (!this.callbacks.Contains(callback))
            {
                this.callbacks.Add(callback);
            }
            // send a message back to the client
            CallClients("Added a new callback");
            return true;
        }
    }
