    BlockingCollection<string> myListOfUrls = new BlockingCollection();
    public void StartThreads()
    {
        if(myListOfUrls.IsComplete == true)
            //Check to see if it has finished loading and processing the urls and act accordingly.
        
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
