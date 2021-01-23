    private List<List<string>> _listOfLists;
    
    public void CreateListOfLists()
    {
        var waitHandles = new List<WaitHandle>();
    
        foreach (int count in Enumerable.Range(1, 5))
        {
            var t = new Thread(CreateListOfStringWorker);
            var handle = new ManualResetEvent(false);
            t.Start(handle);
            waitHandles.Add(handle);
        }
        
        // wait for all threads to complete by calling Set()
        WaitHandle.WaitAll(waitHandles.ToArray());
    
        // do something with _listOfLists
        // ...
    }
    
    public void CreateListOfStringWorker(object state)
    {
        var list = new List<string>();
        lock (_listOfLists)
        {
            _listOfLists.Add(list);
        }
        
        list.Add("foo");
        list.Add("bar");
    
        ((ManualResetEvent) state).Set(); // i'm done
    }
