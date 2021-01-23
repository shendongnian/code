    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class ServiceClient : Form, IMyService_Callback
    {
        // Sync context for enabling callbacks
        SynchronizationContext uiSyncContext;
        
        public ServiceClient()
        {
            InitializeComponent(); //etc.
            uiSyncContext = SynchronizationContext.Current;
            // Create proxy and subscribe to receive callbacks
            var factory = new DuplexChannelFactory<IMyService>(typeof(ServiceClient), "NetTcpBinding_IMyService");
            var proxy = factory.CreateChannel(new InstanceContext(this));
            proxy.Subscribe();
        }
        // Implement callback method
        public void NotifyClients(string message)
        {
            // Tell form thread to update the message text field
            SendOrPostCallback callback = state => this.Log(message);
            uiSyncContext.Post(callback, "Callback");
        }
        // Just updates a form text field
        public void Log(string message)
        {
            this.txtLog.Text += Environment.NewLine + message;
        }
    }    
