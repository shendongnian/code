    void _timer_Tick(object sender, EventArgs e)
    {
        if (!backgroundWorker1.IsBusy)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
