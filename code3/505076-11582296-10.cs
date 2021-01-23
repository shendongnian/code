    BlockingCollection<string> myListOfUrls = new BlockingCollection();
    //Parallel.Foreach will block until it is done so you may want to run this function on a background worker.
    public void StartThreads()
    {
        if(myListOfUrls.IsComplete == true)
        {
            //The collection has emptied itself and you told it you where done using it, you will either need to throw a exception or make a new collection.
            //use IsCompleatedAdding to check to see if you told it that you are done with it, but there still may be members left to process.
            throw new InvalidOperationException();
        }
        //We create a Partitioner to remove the buffering behavior of Parallel.ForEach, this gives better performance with a BlockingCollection.
        var partitioner = Partitioner.Create(myListOfUrls.GetConsumingEnumerable(), EnumerablePartitionerOptions.NoBuffering);
        Parallel.ForEach(partitioner, ProcessUrl);
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
