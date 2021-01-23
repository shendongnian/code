    private void StartOrStop(object sender, EventArgs e)
    {
        // If there is a task, then stop it.
        if (task != null)
        {
            // Dispose of the source when done.
            using (cancellationTokenSource)
            {
                // Cancel.
                cancellationTokenSource.Cancel();
            }
            
            // Set values to null.
            task = null;
            cancellationTokenSource = null;
            // Update UI.
            startStopButton.Content = "Resume";
        }
        else
        {
            // Update UI.
            startStopButton.Content = "Stop";
            // Create the cancellation token source, and
            // pass the token in when starting the task.
            cancellationTokenSource = new CancellationTokenSource();
            task = GetNextPeakAsync(cancellationTokenSource.Token);
        }
    }
