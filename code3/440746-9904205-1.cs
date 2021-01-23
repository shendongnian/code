    public async void HandleButtonClick(object sender, EventArgs e)
    {
        // All of this method will run in the UI thread, which it needs
        // to as it touches the UI... however, it won't block when it does
        // the web operation.
        string url = urlTextBox.Text;
        WebClient client = new WebClient();
        string webText = await client.DownloadStringTaskAsync(url);
        // Continuation... automatically called in the UI thread, with appropriate
        // context (local variables etc) which we used earlier.
        sizeTextBox.Text = string.Format("{0}: {1}", url, webText.Length); 
    }
