    public async void DoWork()
    {
        RequestHandler _handler = new RequestHandler();
        string[] mUrls;
        await _handler.ParseSpecific(mUrls);
        Console.WriteLine("Done...");
    }
...
    public async TaskParseSpecific(string[] urls)
    {
        foreach(string v in urls)
        {
            // Refactored for readability, although I'm not sure it really
            // makes sense now that it's clearer! Are you sure this is what
            // you want?
            var page = await QueryWebPage(v);
            Queue.Add(new Query(page, false);
        }
        Queue.CompleteAdding();
        await ConsumerTask;
        await ParseAll(true);
    }
