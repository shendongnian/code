    try
    {
        stopWatch.Reset();
        stopWatch.Start();
    
    do
    {
        try
        {
             _app = new EmailReportApp();
             _app.Start();
        }
        catch(Exception e)
        {
            ...
        }
    }
    while(!stopWatch.WaitOne(0, false))
