    Queue<string> MyQueue;
    void MyProc()
    {
        string[] filenames = Directory.GetFiles(...);
        MyQueue = new Queue(filenames);
        // start two threads
        Thread t1 = new Thread((ThreadStart)ProcessQueue);
        Thread t2 = new Thread((ThreadStart)ProcessQueue);
        t1.Start();
        t2.Start();
        // main thread processes the queue, too!
        ProcessQueue();
        // wait for threads to complete
        t1.Join();
        t2.Join();
    }
    private object queueLock = new object();
    void ProcessQueue()
    {
        while (true)
        {
            string s;
            lock (queueLock)
            {
                if (MyQueue.Count == 0)
                {
                    // queue is empty
                    return;
                }
                s = MyQueue.Dequeue();
            }
            ProcessFile(s);
        }
    }
