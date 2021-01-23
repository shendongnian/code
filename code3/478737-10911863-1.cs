    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //to be fair, sometimes i create the ApplicationRoot(JUST MainWindow with view first, and just the rest with viewmodel first.)
            var mainvm = new MainViewModel();
            var mainview = new MainWindow {DataContext = mainvm};
            this.MainWindow = mainview;
            this.MainWindow.Show();
        }
    }
