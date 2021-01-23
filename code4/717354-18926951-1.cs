    using System.Deployment.Application;
    ...
    private void DisplayChangeLog()
    {
        if (!ApplicationDeployment.IsNetworkDeployed)
            return;
        if (!ApplicationDeployment.CurrentDeployment.IsFirstRun)
            return;
        ThreadPool.QueueUserWorkItem(state =>
            Execute.OnUIThread(() => <Pop up window with latest changes> ));
    }
