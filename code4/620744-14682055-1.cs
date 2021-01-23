    ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
    
    void GotNewZip(string pathToZip)
    {
        queue.Enqueue(pathToZip); // Added a new work item to the queue
    }
    
    void MethodCalledByWorker()
    {
        while (true)
        {
            if (queue.IsEmpty)
            {
                // Supposedly no work to be done, wait a few seconds and check again (new iteration)
                Thread.Sleep(TimeSpan.FromSeconds(5));
                continue;
            }
            
            string pathToZip;
            if (queue.TryDequeue(out pathToZip)) // If TryDeqeue returns false, another thread dequeue the last element already
            {
                HandleZipFile(pathToZip);
            }
        }
    }
