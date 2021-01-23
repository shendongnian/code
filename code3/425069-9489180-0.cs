    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        // Login
        var login = new LoginDialog();
        var loginVm = new LoginViewModel();
        login.DataContext = loginVm;
        login.ShowDialog();
        if (!login.DialogResult.GetValueOrDefault())
        {
            // Error is handled in login class, not here");
            Environment.Exit(0);
        }
        // If login is successful, show main application
        var app = new ShellView();
        var appModel = new ShellViewModel();
        app.DataContext = viewModel;
        app.Show();
    }
