    object lockObj = new object();
    lock (lockObj)
    {
        if (!IsProxyDequeue)
        {
            // get the proxy
            IsProxyDequeue = true;
        }
        oReqReview.Proxy = new   WebProxy(httpProxy, 8989);
    }
