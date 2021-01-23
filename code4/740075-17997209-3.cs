    void webClient_DownloadStringCompleted(s, e)
    {
        Dispatcher.BeginInvoke( () =>
        {
            progressIndicator.IsVisible = false;
            // Your code
        });
    }
        
