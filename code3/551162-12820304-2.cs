    private void StatusUpdate(object sender, ProgressEventArgs args)
    {    
        if (Dispatcher.Thread.ManagedThreadId != Thread.CurrentThread.ManagedThreadId)
        {
            // call from a worker thread
            var statusUpdateDelegate = new ProgressChangedHandler(this.StatusUpdate);
    
            Dispatcher.Invoke(statusUpdateDelegate, DispatcherPriority.Normal, sender, args);
        }
        else
        {
            // direct call from the UI thread
            lblProgress.Content = args.Message;
            pbProgress.Value = args.Percentage;
        }
    }
