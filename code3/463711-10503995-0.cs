    private void bwQuoteUpdate_DoWork(object sender, DoWorkEventArgs e)
    {
        // Code here runs on background thread.
        Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(() =>
        {
            // Code here runs on UI thread.
        }));
    }
