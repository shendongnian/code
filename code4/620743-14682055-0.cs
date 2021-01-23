    Queue<string> queue = new Queue<string>();
    object queueLock = new object();
    
    void GotNewZip(string pathToZip)
    {
        lock (queueLock)
        {
            queue.Enqueue(pathToZip); // Added a new work item to the queue
        }
    }
    
    void MethodCalledByWorker()
    {
        while (true)
        {
            if (!queue.Count > 0)
            {
                // Supposedly no work to be done, wait a few seconds and check again (new iteration)
                Thread.Sleep(TimeSpan.FromSeconds(5));
                continue;
            }
            
            // lock and check again
            lock (queueLock)
            {
                var pathToZip = queue.Dequeue();
                if (pathToZip != null) // check again, just in case another thread dequeue it already while checking for Count
                {
                    HandleZipFile(pathToZip);
                }
            }
        }
    }
