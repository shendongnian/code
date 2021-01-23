    public void RequestAccountInfo()
    {
        var task = Task<AccountInfo>.Factory.StartNew(() => 
            bridge.GetAccountInfo(), 
            TaskScheduler.FromCurrentSynchronizationContext());
        task.ContinueWith(t => { OnAccountInfoUpdated(new AccountInfoEventArgs(t.Result)); });
    }
