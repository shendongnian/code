    protected void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes.Add(
            new System.ServiceModel.Activation.ServiceRoute("books",
                new System.ServiceModel.Activation.WebServiceHostFactory(),
                typeof(BookStore.Services.BookService)
            )
        );
    }
