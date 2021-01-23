    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        using(StreamReader reader = new StreamReader(e.Argument as String, Encoding.UTF8))
        {
            while(!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                backgroundWorker.ReportProgress(0, line);
                Thread.Sleep(1000);
                if (backgroundWorker.CancellationPending) 
                    return;
            }
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        label1.Text = e.UserState as String;
    }
