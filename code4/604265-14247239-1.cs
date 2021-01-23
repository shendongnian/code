    public void WaitForStatus(ServiceController sc, ServiceControllerStatus statusToWaitFor,
        TimeSpan timeout, CancellationToken ct)
    {
        var endTime = DateTime.Now + timeout;
        while(!ct.IsCancellationRequested && DateTime.Now < endTime)
        {
             sc.Refresh();
             if(sc.Status == statusToWaitFor)
                 return;
             
             // may want add a delay here to keep from
             // pounding the CPU while waiting for status
        }
        if(ct.IsCancellationRequested)
        { /* cancel occurred */ }
        else
        { /* timeout occurred */ }
     }
