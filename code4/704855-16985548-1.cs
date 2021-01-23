    private void DoBackgroundWork(object sender, DoWorkEventArgs e)
    {
        String MyLog = Directory.GetCurrentDirectory() + "\\MyLog.txt";
    
        while (!_worker.CancellationPending)
        {
            using (StreamWriter writer = new StreamWriter(MyLog, true))
            {
                writer.Write("Hello");
            }
            Thread.Sleep(1000);
        }
    }
