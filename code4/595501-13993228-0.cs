    while(!System.Diagnostics.Debugger.IsAttached)
    {
        System.Threading.Thread.Sleep(100);
    }
    smThread = new Thread(delegate() { sm.RunServerMonitor(ref run); });
    smThread.Start();
    dailyThread = new Thread(delegate() { dailyEvents(); });
    dailyThread.Start();
