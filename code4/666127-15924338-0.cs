    public Task DownloadData(CancellationToken tok)
    {
        tok.ThrowIfCancellationRequested();//check that it hasn't been cancelled.
    
       //while doing your task check
       
      if (tok.IsCancellationRequested)
        {
                        // whatever you need to clean up.
                        tok.ThrowIfCancellationRequested();
         }
    
    
    }
