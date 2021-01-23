    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        var defferal = taskInstance.GetDeferral();
        ServiceReference.WebServiceSoapClient test = new ServiceReference.WebServiceSoapClient();
        var nb = await test.GetLatestDataAsync("temp");
        double temperature = nb.Value;
        string unit = nb.Unit;
        string latestTemp = " " + nb.Value + " " + nb.Unit;
        // move up
        // var defferal = taskInstance.GetDeferral();
        ...
