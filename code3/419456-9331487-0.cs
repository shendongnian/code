    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var app = new ShellView();
            var context = new ShellViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
