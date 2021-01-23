    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        MyCustomObject cancellationStatus = e.Argument as MyCustomObject
        while(!cancellationStatus.Cancelled)
        {
            cpuView();
            gpuView();
            Thread.Sleep(1000);
        }
    }
