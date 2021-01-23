    private Queue<string> myQueue = new Queue<string>();  // owned by the logger
    void WriteLog(string s)
    {
        lock (myQueue)
        {
            myQueue.Enqueue(s);
        }
    }
