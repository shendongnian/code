    protected override void OnStartup(StartupEventArgs e)
    {
        IKernel kernel = new StandardKernel();
        kernel.Bind<ITest>().To<Test>();
    
        var mainWindow = kernel.Get<MainWindow>();
        mainWindow.Show();
    
        base.OnStartup(e);
    }
