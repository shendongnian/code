    void ProcessJobs(bool isFirst)
    {
        var job = Queue.PopJob(); // assumes PopJob() is thread-safe
        if (job == null)
            return;
    
        if (isFirst)
            Task.Factory.StartNew(() => ProcessJobs(true));
        job.Execute();
    
        Task.Factory.StartNew(() => ProcessJob(false));
    }
