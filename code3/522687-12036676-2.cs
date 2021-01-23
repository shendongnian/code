    // Start worker thread
    ThreadPool.QueueUserWorkItem(state =>
    {
        // Long running logic here
       findListText.Dispatcher.BeginInvoke(() => findListText.Text = "Processing request. Please wait...");
       Find(bool.Parse("False" as string)); 
        // Tip: Run change on GUI thread from the worker using the dispatcher
        findListText.Dispatcher.BeginInvoke(() => findListText.Text = "Search completed.");
    });
