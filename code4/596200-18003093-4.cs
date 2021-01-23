    Semaphore MySem = new Semaphore(3, 3);
    void MyProc()
    {
        string[] filenames = Directory.GetFiles(...);
        foreach (string s in filenames)
        {
            mySem.WaitOne();
            ThreadPool.QueueUserWorkItem(ProcessFile, s);
        }
        // wait for all threads to finish
        int count = 0;
        while (count < 3)
        {
            mySem.WaitOne();
            ++count;
        }
    }
    void ProcessFile(object state)
    {
        string fname = (string)state;
        // do whatever
        mySem.Release();  // release so another thread can start
    }
