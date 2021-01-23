    ...
    using (HttpSelfHostServer server = new HttpSelfHostServer(config))
    {
        server.OpenAsync().Wait();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new frmMainMenu());
    }
    ...
