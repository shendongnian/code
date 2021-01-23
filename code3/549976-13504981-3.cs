    class Module {
      public void JobCompleted(IAsyncResult r) {
        if(!r.IsCompleted)
          return;
      
        Console.WriteLine("The job has finished.");
      }
      public void ExecuteJob() {
        var job = new EventArgs<JobEventArgs>((s, a) => { this.controller.JobA(); });
        job.BeginInvoke(null, null, 
          r => 
          { 
            this.JobCompleted(r); 
            if(r.IsCompleted) 
              job.EndInvoke(r); 
          }, null);
      }
    }
