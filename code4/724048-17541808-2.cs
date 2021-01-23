    using System.Threading.Tasks;
    
    // ...
    Data data;
    
    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            Task.Delay(5 * 60 * 1000).Wait();
            RefreshData();
        }
    }, TaskCreationOptions.LongRunning);
    
    // use data for calculations
