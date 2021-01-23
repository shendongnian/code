    BlockingCollection<string> myListOfUrls = new BlockingCollection();
    //Parallel.Foreach will block until it is done so you may want to run this function on a background worker.
    public void StartThreads()
    {
        if(myListOfUrls.IsComplete == true)
            //The collection has emptied itself and you told it you where done using it, you will either need to throw a exception or make a new collection.
            //use IsCompleatedAdding to check to see if you told it that you are done with it, but there still may be members left to process.
        
        Parallel.Foreach(myListOfUrls, ProcessUrl);
    }
    public void StopThreads()
    {
        myListOfUrls.CompletedAdding()
    }
    public void AddUrl(string url)
    {
        myListOfUrls.Add(url);
    }
    
    private void ProcessUrl(string url)
    {
        //Do your work here, this code will be run from multiple threads.
    }
