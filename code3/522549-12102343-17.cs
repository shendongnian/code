    private void RaiseRequerySuggested()
    {
        ...
        _requerySuggestedOperation = dispatcher.
            BeginInvoke(
                DispatcherPriority.Background,
                new DispatcherOperationCallback(RaiseRequerySuggested),
                null); // dispatcher is the Dispatcher for the current thread.
        ...
    }
