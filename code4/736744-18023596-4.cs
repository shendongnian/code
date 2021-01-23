    // Create a new background worker.
    var bgw = new BackgroundWorker();
    // Assign a delegate to perform the background work.
    bgw.DoWork += (s, e) =>
        {
            // Runs in background thread. Unhandled exceptions
            // will cause the thread to terminate immediately.
            throw new StackOverflowException();
        };
    // Assign a delegate to perform any cleanup/error handling/UI updating.
    bgw.RunWorkerCompleted += (s, e) =>
        {
            // Runs in UI thread. Any unhandled exception that
            // occur in the background thread will be accessible
            // in the event arguments Error property.
            if (e.Error != null)
            {
                // Handle or rethrow.
            }
        };
    // Start the background worker asynchronously.
    bgw.RunWorkerAsync();
