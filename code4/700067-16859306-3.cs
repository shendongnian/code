    do
    {
        try
        {
             _app = new EmailReportApp();
             _app.Start();
        }
        catch(Exception e)
        {
            ... handle error or log however you want
        }
    }
    while(!stop.WaitOne(0, false))
