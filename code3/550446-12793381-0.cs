    bool createdNew = true;
    using (Mutex mutex = new Mutex(true, "MyApplicationName", out createdNew))
    {
    if (createdNew)
    {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new MainForm());
    }
    }
