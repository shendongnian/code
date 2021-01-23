    bool stop = false;
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        while(true)
        {
            if(stop)
                break; // this will exit the while loop
            cpuView();
            gpuView();
            Thread.Sleep(1000);
        }
    }
