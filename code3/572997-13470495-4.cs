    public IEnumerator<YieldInstruction> DoAsync()
    {
        HttpClient client = ....;
        client.DownloadAsync(..);
        
        String result;
        while (client.IsDownloading)
        {
            // Update the progress bar
            progressBar.Value = client.Progress;
            // Wait one update
            yield return YieldInstruction.WaitOneUpdate;
        }
        // Process result here
    }
