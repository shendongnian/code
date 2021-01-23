    var targetAssembly = typeof(PracticeManagement.MainWindow).Assembly;
    var currentAssembly = this.GetType().Assembly;
    Application.ResourceAssembly = targetAssembly;
    var rd = (ResourceDictionary)Application.LoadComponent(new Uri("/ProjectName;component/CommonUIStylesDictionary.xaml", UriKind.Relative));
    if (Application.Current == null)
    {
        var x = new System.Windows.Application(); // magically is assigned to application.current behind the scenes it seems
    }
    Application.Current.Resources = rd;
    var mainWindow = new ProjectName.MainWindow(this.Connection.ConnectionString);
    mainWindow.Show();
