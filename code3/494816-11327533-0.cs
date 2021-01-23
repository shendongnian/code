    private void ExecuteOnDispatcherThread(Action action)
    {
        if (!this.Dispatcher.CheckAccess()) {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, action); 
        }
        else {
            action();
        }
    }
