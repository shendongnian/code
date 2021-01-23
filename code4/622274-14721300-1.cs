    Main()
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        worker.RunWorkerAsync();
    }
    bool exitBGThread = false;
    public void worker_DoWork(object sender, EventArgs e)
    {
        TimeSpan interval = new TimeSpan(0, 0, 1);
        while (!exitBGThread)
        {
            DateTime start = DateTime.Now;
            AutoChecking();  // thats a function should Run on Background every 1 second
            while (!exitBGThread)
            {
                DateTime cur = DateTime.Now;
                if (cur - start >= interval)
                    break;
                Thread.Sleep(100);
            }
        }
    }
    public void AutoChecking()
    {
        this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
        {
            if (SystemisGood  == true )
                 Updatecolor.Fill = Green;
            else 
                 Updatecolor.Fill = Red;
        }));
    }
