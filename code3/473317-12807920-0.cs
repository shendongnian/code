    static Task<String> DownloadStringAsync(Uri uri)
    {
        // Create a WebClient
        var wc = new WebClient();
    
        // Set up your web client.
    
        // Create the TaskCompletionSource.
        var tcs = new TaskCompletionSource<string>();
    
        // Set the event handler on the web client.
        wc.DownloadStringCompleted += (s, e) => {
            // Dispose of the WebClient when done.
            using (wc)
            {
                // Set the task completion source based on the
                // event.
                if (e.Cancelled)
                {
                    // Set cancellation.
                    tcs.SetCancelled();
                    return;
                }
    
                // Exception?
                if (e.Error != null)
                { 
                    // Set exception.
                    tcs.SetException(e.Error);
                    return;
                }
    
                // Set result.
                tcs.SetResult(e.Result);
            };
    
        // Return the task.
        return tcs.Task;
    };
