    BackgroundWorker bgw = new BackgroundWorker();
    bgw.DoWork += (_, args) =>
    {
        List<Task> tasks = new List<Task>();
    
        tasks.Add(Task.Factory.StartNew(() => DoStuff()));
        tasks.Add(Task.Factory.StartNew(() => DoStuff2()));
        tasks.Add(Task.Factory.StartNew(() => DoStuff3()));
    
        Task.WaitAll(tasks.ToArray());
    };
    bgw.RunWorkerCompleted += (_, args) => updateUI();
    bgw.RunWorkerAsync();
