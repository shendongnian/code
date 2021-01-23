    public ActionResult Index()
    {
        var taskId = Guid.NewGuid().ToString();
        var policy = new CacheItemPolicy
        {
            Priority = CacheItemPriority.NotRemovable,
            // Adjust the value to some maximum amount of time that your task might run
            AbsoluteExpiration = DateTime.Now.AddHours(1)
        };
        MemoryCache.Default.Set(taskId, "running", policy);
        Task.Factory.StartNew(key => 
        {
            // simulate a long running task
            Thread.Sleep(10000);
            // the task has finished executing => we could now remove the entry from the cache.
            MemoryCache.Default.Remove((string)key);
        }, taskId);
        return View((object)taskId);
    }
