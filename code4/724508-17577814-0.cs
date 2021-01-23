    private AutoResetEvent _dashboardStartWaitEvent = new AutoResetEvent(false);   
    internal void SetupAndRunDashboard()
    {
        if (DashboardUiThread == null)
        {
            DashboardUiThread = new Thread(RunDashboard) { Name = "dashboardUIThread" };
            DashboardUiThread.SetApartmentState(ApartmentState.STA);
            DashboardUiThread.Start();
            _dashboardStartWaitEvent.Wait();
        }
    }
    private void RunDashboard()
    {
        UIDashBoard = new Dashboard(this);
        _dashboardStartWaitEvent.Set();
        Dispatcher.Run();
    }
