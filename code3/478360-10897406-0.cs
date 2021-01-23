    void PerformOperationOnAllSites(Action<SiteOperation> doIt) {
        foreach (Sites site in _sitesManagement.GetAll()) {
            SiteOperation siteOperation = new SiteOperation(site);
            doIt(siteOperation);
        }
    }
    ...
    _sitesManagement.PerformOperationOnAllSites(op => op.LimitBandwidth(wantedBandwidthInLBps));
    _sitesManagement.PerformOperationOnAllSites(op => op.KillJames());
    _sitesManagement.PerformOperationOnAllSites(op => op.FlyToMoon(2012, new TaskIdentifier(10,20));
