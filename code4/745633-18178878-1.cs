        ServicePointManager.DefaultConnectionLimit = _DefaultConnections;
        ServicePointManager.MaxServicePointIdleTime = _MaxIdleTime;
        ServicePointManager.Expect100Continue = false;
        ServicePointManager.CheckCertificateRevocationList = false;
        throttle = new SemaphoreSlim(initialCount: _MaxQueue);
