    private void HandleRefreshOrders()
    {
        if (IsBusy)
            return;
        IsBusy = true;
    
        var task = Task.Factory.StartNew(() => RefreshOrders());
        task.ContinueWith(t => 
                {
                    RefreshOrdersCompleted(t.Result);
                    IsBusy = false;
                }, 
            CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,  TaskScheduler.FromCurrentSynchronizationContext());
        task.ContinueWith(t => 
                {
                    this.LogAggregateException(t.Exception, Resources.OrdersEditorVM_OrdersLoading, Resources.OrdersEditorVM_OrdersLoadingFaulted);
                    IsBusy = false;
                },
        CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
    }
