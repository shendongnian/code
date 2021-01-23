    public CurrentlyActiveWndConnectionInfo CurrentlyActiveWndConnectionInfo
    {
        get
        {
            STrace.Params("ScriptFactory", "ScriptFactory.CurrentlyActiveWndConnectionInfo", string.Empty, null);
            if (ServiceCache.VSMonitorSelection == null)
            {
                STrace.LogExThrow();
                throw new InvalidOperationException();
            }
            return this.GetCurrentlyActiveWndConnectionInfo(ServiceCache.VSMonitorSelection);
        }
    }
