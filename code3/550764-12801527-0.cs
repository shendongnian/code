    AutoResetEvent autoResetEvent;
    
    main()
    {
        autoResetEvent = new AutoResetEvent(false);
        Parallel.For(0, dtPP.Rows.Count, i =>
        {
            // your code
        });
        autoResetEvent.WaitOne();
        DoSomething();
     }
    
    void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
       ...
       if(ezer)
       {
           autoResetEvent.Set();
       }
    
    }
