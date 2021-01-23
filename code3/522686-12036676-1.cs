    // Start worker thread
    ThreadPool.QueueWorkerItem(state =>
    {
        // Long running logic here
       findListText.Dispatcher.BeginInvoke(() => findListText.Text = "Processing request. Please wait...");
       Find(bool.Parse("False" as string)); 
        // Run change on GUI thread from the worker
        findListText.Dispatcher.BeginInvoke(() => findListText.Text = "Search completed.");
    });
