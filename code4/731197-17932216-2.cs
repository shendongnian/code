    public partial class App 
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            IStatusBarViewModel iStatusBarViewModel = new StatusBarViewModel();
            MainViewModel mainViewModel = new MainViewModel(iStatusBarViewModel);
            OtherViewModel otherViewModel = new OtherViewModel(iStatusBarViewModel);
            MainWindow mainWindow = new MainWindow
                {
                    StatusBarDp = iStatusBarViewModel, 
                    MainContentDp = mainViewModel
                };
            mainWindow.Show();
        }
    }
