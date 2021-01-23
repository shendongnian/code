    public partial class App : Application
    {
       protected override void OnStartup(StartupEventArgs e)
       {
          base.OnStartup(e);
          var mainWindow = new MainWindow();
          var viewModel = new MainViewModel();
          mainWindow.DataContext = viewModel; // Bind the ViewModel to the Window Datacontext.
          mainWindow.Show();
       }
    }
