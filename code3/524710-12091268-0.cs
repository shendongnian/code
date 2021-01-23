    BackgroundWorker worker = new BackgroundWorker();
    worker.WorkerReportsProgress = true;
    worker.DoWork += delegate(object s, DoWorkEventArgs args)
    {
        worker.ReportProgress(1, "Step1");
        Thread.Sleep(1000);
        worker.ReportProgress(2, "Step2");
        Thread.Sleep(1000);
        worker.ReportProgress(3, "Step3");
    };
    worker.ProgressChanged += delegate(object s, ProgressChangedEventArgs args)
    {
        string step = (string)args.UserState;
        Messages.Clear();
        Messages.Add(new Message(step));
    };
    worker.RunWorkerAsync();
