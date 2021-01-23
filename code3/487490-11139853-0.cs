    void ProcessJobs(bool isFirst)
    {
        if (isFirst)
            Task.Factory.StartNew(() => ProcessJobs(true));
    
        var job = Queue.PopJob(); // assumes PopJob() is thread-safe
        if (job == null)
            return;
    
        job.Execute();
    
        Task.Factory.StartNew(() => ProcessJob(false));
    }
