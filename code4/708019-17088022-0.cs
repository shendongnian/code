    static SynchronizationContext syncCtx;
    static ServiceHost serviceHost;
    static void Main(string[] args)
    {
        AsyncContext.Run(() =>
        {
            syncCtx = SynchronizationContext.Current;
            syncCtx.OperationStarted();
            serviceHost = new ServiceHost(typeof(MessageService));
            Console.CancelKeyPress += Console_CancelKeyPress;
            var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            serviceHost.AddServiceEndpoint(typeof(IMessageService), binding, address);
            serviceHost.Open();
        });
    }
    static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
        if (serviceHost != null)
        {
            serviceHost.BeginClose(_ => syncCtx.OperationCompleted(), null);
            serviceHost = null;
        }
        if (e.SpecialKey == ConsoleSpecialKey.ControlC)
            e.Cancel = true;
    }
