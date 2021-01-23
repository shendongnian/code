    void YourTask()
    {
        string[] urls = {"url1","url2","url3"};
        ConcurrentList<MyTypedResult> ResultCollection = new ConcurrentList<MyTypedResult>();
        Parallel.ForEach(urls, url => 
        {
            GetData(url);
            ResultCollection.TryAdd(myTypedResult);
        );
        //on this line all parallel task will be completed and ResultCollection will be filled with the results
    }
    private MyTypedResult GetData(string url)
    {
       WebClient wc = new WebClient();
        var content = wc.DownloadString(url);
        MyTypedResult r = Process(content);
        return r;
    }
