    private static void OnBeginRequest(object sender, EventArgs e)
    {
        if (RouteTable.Routes.Last<RouteBase>() != DebugRoute.Singleton)
        {
            RouteTable.Routes.Add(DebugRoute.Singleton);
        }
    }
