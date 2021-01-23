    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        using (var process = new Process())
        {
            //...
    
            process.Start()
    
            //...
            while(true)
            { 
                if ((sender as BackgroundWorker).CancellationPending && !process.HasExited)
                {
                  process.Kill();
                  break;
                }
                Thread.Sleep(100);
             }
    
            process.WaitForExit();
        }
    }
    
   
