    private void bwQuoteUpdate_DoWork(object sender, DoWorkEventArgs e)
    {
        // Code here runs on background thread.
        QuoteInfo info = e.Argument as QuoteInfo;
        string result = PerformLongRunningProcessing(info);
        Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(() =>
        {
            // Code here runs on UI thread.
            this.resultTextBox.Text = result;
        }));
    }
