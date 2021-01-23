    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            var factory = new ServiceHostFactory();
            RouteTable.Routes.Add(new ServiceRoute("", factory, typeof(TestMutliHeadService)));
        }
    }
