    void initialize(){
    ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
    foreach(string url in websites)
    {
        queue.Enqueue(url);
    }
    //and the threads
    List<Thread> threads = new List<Thread>();
    for (int i = 0; i < threadCountFromTheUser; i++)
    {
        threads.Add(new Thread(work));
    }}
    
    //work method
    void work()
    {
        while (!queue.IsEmpty)
        {
            string url;
            bool fetchedUrl = queue.TryDequeue(out url);
            if (fetchedUrl)
                ping(url);
        }
    }
