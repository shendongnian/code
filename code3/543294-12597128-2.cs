    cancelTokenSourceOfFilterTask = new CancellationTokenSource();
    cancelTokenOfFilterTask = cancelTokenSourceOfFilterTask.Token;
    
    Task task = null;
    task = Task.Factory.StartNew(() =>
    {
        VoltLoader vl = new VoltLoader();
        var listOfVolts = vl.LoadVoltsOnFilter(_sourceOfCachableData, ChosenFilter);
        SelectableVolts = new ObservableCollection<SelectableVoltsModel>(listOfVolts);
    }, cancelTokenOfFilterTask);
    
    task.ContinueWith(ant => 
    {
        switch (ant.Status)
        {
            // Handle any exceptions to prevent UnobservedTaskException.             
            case TaskStatus.RanToCompletion:
                if (asyncTask.Result)
                {
                    // Do stuff...
                }
                else
                {
                    // Do stuff...
                }
                break;
            case TaskStatus.Canceled:
                // If Cancelled you can start the task again reading the new settings.
                break;
            case TaskStatus.Faulted:
                break;
        }
    }, CancellationToken.None, 
       TaskContinuationOptions.None, 
       TaskScheduler.FromCurrentSynchronizationContext());
    
