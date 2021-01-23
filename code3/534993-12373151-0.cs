    // Get UI scheduler. Use this to update ui thread in continuation.
    TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    // You can use TPL like this...
    List<object> objList = new List<object>();
    Task<object[]> task = Task.Factory.StartNew<object[]>(() =>
        {
            // Pull all your data into some object.
            object[] objArr = new object[] { "Some", "Stuff", "..." };
            return objArr;
        }, TaskCreationOptions.PreferFairness);
    // Continuation firs after the antecedent task is completed.
    task.ContinueWith(ant =>
        {
            // Get returned data set.
            object[] resultSet = (task.Result as object[]);
            // Check task status.
            switch (task.Status)
            {
                // Handle any exceptions to prevent UnobservedTaskException.             
                case TaskStatus.RanToCompletion:
                    if (task.Result != null)
                    {
                        // Update UI comboBox.
                    }
                    break;
                default:
                    break;
            }
        }, CancellationToken.None, TaskContinuationOptions.None, uiScheduler);
