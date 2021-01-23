    protected void Application_Start(object sender, EventArgs e)
    {
       RegisterRoutes(RouteTable.Routes);
    }
    private void RegisterRoutes(RouteCollection routes)
    {
       routes.MapPageRoute("customer-reservation", // name of the route
                           "Customer/Reservation", // url to look for
                           "~/Pages/reservation.aspx");  // existing file to map to
    }
