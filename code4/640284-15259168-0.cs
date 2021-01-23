    IEnumerable<HttpContent> parts = null;
    Task.Factory
        .StartNew(() => parts = Request.Content.ReadAsMultipartAsync().Result.Contents,
            CancellationToken.None,
            TaskCreationOptions.LongRunning, // guarantees separate thread
            TaskScheduler.Default)
        .Wait();
    
