    Task.Factory.StartNew<IEnumerable<RequestSyncPlain>>(() =>
    {
      return result;
    }).ContinueWith(_ =>
    {
      try
      {
        _.Wait();
      }
      catch (AggregateException ae)
      {
      }
    
      foreach (var requestSyncPlain in _.Result)
      {
        var requestSync = new RequestSyncViewModel(requestSyncPlain);
        
        requestSyncObservableCollection.Add(requestSync);
      }
    }, TaskScheduler.FromCurrentSynchronizationContext());
