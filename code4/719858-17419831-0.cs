    // var sites = your sites list
    var processTask = Task.Foreach(sites, site =>
    {
        Task.Factory.StartNew(theSite=>
        {
            theSite.UnzipLogs()
        }.ContinueWith(unzipTask=>{
        {
            theSite.ParseLogs();
        }.ContinueWith(parseTask=>{
        {
            theSite.AnalyzeLogs();
        }
    });
    Task.WaitAll(processTask);
