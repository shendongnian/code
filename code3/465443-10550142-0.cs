    protected void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }
    private void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("DummyRouteName", "Dummy", "~/Default.aspx");
        ....
    }
