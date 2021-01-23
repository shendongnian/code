    protected override void OnStartup(object sender, StartupEventArgs e)
            {
                var windowManager = IoC.Get<IWindowManager>();
                var viewModel = IoC.Get<IShell>();
    
                viewModel.LoginSuccessful =
                    () => GuardCloseAndReopen("Content");
    
                viewModel.Logout =
                    () => GuardCloseAndReopen("Login");
    
                windowManager.ShowWindow(viewModel, "Login");
            }
    
            private void GuardCloseAndReopen(ShellViewMode shellViewMode)
            {
                var windowManager = IoC.Get<IWindowManager>();
                var shellScreen = IoC.Get<IShell>() as Screen;
    
                Application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
    
                shellScreen.TryClose();
    
                Application.ShutdownMode = ShutdownMode.OnLastWindowClose;
    
                windowManager.ShowWindow(shellScreen, shellViewMode);
            }
