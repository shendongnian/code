    private async Task StartAsync()
    {
        var tasks = new List<Task>()
        foreach (var url in urls)
        {
            tasks.Add(ParseHtml(url));
        }
        // now you have a sequence of Tasks scheduled to be run, possibly simultaneously.
        // you can do some other processing here
        // once you need to be certain that all tasks are finished await Task.WhenAll(...)
        await Task.WhenAll(tasks);
        // Task.WhenAls(...) returns a Task, hence you can await for it
        // the return of the await is a void
    }
