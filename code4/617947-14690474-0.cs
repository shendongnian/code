    Dictionary<string, string> telResult = null,
                               nameResult = null;
    BackgroundWorker bw = new BackgroundWorker();
    bw.WorkerSupportsCancellation = true;
    bw.DoWork += (obj, e) => nameResult = SearchByName(name, bw);
    bw.RunWorkerAsync();
    if(!string.IsNullOrWhiteSpace(telNum))
        telResult = SearchByTelNum(telNum);//Will return null if a match is not found
    if(telResult != null)
    {
        bw.CancelAsync;
        return telResult;
    }
    bool hasTimedOut = false;
    int i = timeOutCount;
    while (bw.IsBusy && !hasTimedOut)
    {
        System.Threading.Thread.Sleep(500);
        if (0 == --i) hasTimedOut = true;
    }
    return nameResult;
