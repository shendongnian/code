    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class MyServiceClient : Form, IAuctionBits_Callback
    {
        SynchronizationContext uiSyncContext;
        public MyServiceClient ()
        {
            // Capture the UI synchronization context
            uiSyncContext = SynchronizationContext.Current;
            // Create proxy and subscribe to receive callbacks
            var factory = new ChannelFactory<IMyService>("EndpointNameInConfig");
            var proxy = factory.CreateChannel();
            proxy.Subscribe();
        }
        // Implement callback method
        public void NotifyClient(string message)
        {
            // Tell form thread to update the message text field
            SendOrPostCallback callback = delegate(object state)
            {
                this.Log(message);
            };
            uiSyncContext.Post(callback, "Callback");
        }
        // Just updates a form text field
        public void Log(string message)
        {
            this.txtLog.Text += Environment.NewLine + message;
        }
    }
