    // Runs when the BackgroundWorker thread terminates.
    private void ThreadFinished(object sender, RunWorkerCompletedEventArgs e)
    {
        // Process any unhandled exception
        if (e.Error != null)
        {
            this.LogError(e.Error.Message, e.Error.StackTrace, blah, blah);
