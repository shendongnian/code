    bool createdNew;
    Mutex m = new Mutex(true, "SomeNameHere", out createdNew);
    if (!createdNew)
    {
        // Application already running. Call it and ask to show it's form.
        IpcClientChannel clientChannel = new IpcClientChannel();
        ChannelServices.RegisterChannel(clientChannel, true);
        RemotingConfiguration.RegisterWellKnownClientType(typeof(ExchangeBase), "ipc://SomeNameHere/YourAppBase");
        ExchangeBase Exchange = new ExchangeBase();
        Exchange.ShowForm();
    }
    else
    {
        IpcServerChannel serverChannel = new IpcServerChannel("SomeNameHere");
        ChannelServices.RegisterChannel(serverChannel, true);
        RemotingConfiguration.RegisterWellKnownServiceType(typeof(ExchangeBase), "YourAppBase", WellKnownObjectMode.SingleCall);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MainForm = new FormMain();
        if (!MainForm.StopLoading)
        {
            Application.Run(MainForm);
            // Keep the mutex reference alive until the termination of the program.
            GC.KeepAlive(m);
        }
    }
