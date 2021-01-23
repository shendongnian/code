    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var vm = new MainViewModel();
        // set vm properties
        var view = new MainView();
        view.DataContext = vm;
        view.Show();
    }
