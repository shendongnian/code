    //RouteTable is of type System.Web.Routing.RouteCollection
    RouteTable.Add(new WebApiRoute(
        "MyService",
        new HttpServiceHostFactory { Configuration = config },
        typeof(MyService)));
