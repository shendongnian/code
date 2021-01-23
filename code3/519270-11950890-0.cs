    Func<Task> taskFunc = async () =>
    {
        var route = await BusDataProviderManager.DataProvider.DataBroker.getRoute(req);
        // Add the route to our array (on UI thread as it's observed)
        await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, delegate
        {
            this.routes.Add(route);
        });
    }
    Task getRouteTask = Task.Run(taskFunc);
