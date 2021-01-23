       public static void Startup()
        {
            var appDomainSetup = new AppDomainSetup()
            {
                ApplicationBase = Path.GetDirectoryName(typeof(WpfHelper).GetType().Assembly.Location)
            };
            AppDomain domain = AppDomain.CreateDomain(DateTime.Now.ToString(), null, appDomainSetup);
            CrossAppDomainDelegate action = () =>
            {
                Thread thread = new Thread(() =>
                {
                    var app = new WpfApplication.App();
                    WpfApplication.App.ResourceAssembly = app.GetType().Assembly;
                    app.MainWindow = new WpfApplication.MainWindow();
                    app.MainWindow.Show();
                    app.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
               
            };
            domain.DoCallBack(action);
        }
}
