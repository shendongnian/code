    int? hours = null;
    Task<int> task = null;
    task = Task.Factory.StartNew<int>
        (
            () => Result());
            task.ContnueWith
              (   cont => 
                  {
        // Some task completion checking...
                     hours = task.Result;
                   }
                  , CancellationToken.None
                  , TaskCreationOptions.None
                  , TaskScheduler.Current
              );
       
