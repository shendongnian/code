    private void CheckJobs(object state)
    {
        lock (Locker)
        {
            // checks job list.
            var jobs = foo.GetIncomingTimeJobs();
            foreach (var job in jobs)
            {
                var thread = new Thread(foo);
                thread.Start();
            }
        }
    }
    
    private void StartProcessing()
    {
        var timer = new System.Threading.Timer(CheckJobs, null, 0, 10000);
    }
