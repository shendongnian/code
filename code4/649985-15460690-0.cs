    const int MaxThreads = 4;
    Semaphore sem = new Semaphore(MaxThreads, MaxThreads);
    while (Queue.HasItems())
    {
        sem.WaitOne();
        var item = Queue.Dequeue();
        Threadpool.QueueUserWorkItem(ProcessItem, item); // see below
    }
    // When the queue is empty, you have to wait for all processing
    // threads to complete.
    // If you can acquire the semaphore MaxThreads times, all workers are done
    int count = 0;
    while (count < MaxThreads)
    {
        sem.WaitOne();
        ++count;
    }
    // the code to process an item
    void ProcessItem(object item)
    {
        // cast the item to whatever type you need,
        // and process it.
        // when done processing, release the semaphore
        sem.Release();
    }
