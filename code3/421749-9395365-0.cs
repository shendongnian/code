    [CompilerGenerated]
    private static DoWorkEventHandler CS$<>9__CachedAnonymousMethodDelegate1;
    [CompilerGenerated]
    private static void <SomeMethod1>b__0(object sender, DoWorkEventArgs e)
    {
        throw new NotImplementedException();
    }
    public void SomeMethod1()
    {
        BackgroundWorker worker = new BackgroundWorker();
        BackgroundWorker backgroundWorker = worker;
        backgroundWorker.DoWork += (object sender, DoWorkEventArgs e) => throw new NotImplementedException();
        worker.RunWorkerAsync();
    }
    public void SomeMethod2()
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += worker_DoWork;
        worker.RunWorkerAsync();
    }
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        throw new NotImplementedException();
    } 
