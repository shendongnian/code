    private void ProcessMessageOnUIThread(YourMessageType msg)
    {
        // Process here
    }
    
    private void ReaderThreadEventHandler(YourMessageType msg)
    {
        // Invoke the UI thread to process the message
        BeginInvoke(new Action(ProcessMessageOnUIThread), msg);
    }
