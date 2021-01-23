    System.Threading.Tasks.TaskScheduler scheUI = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext();
    task.ContinueWith(p => PopulateList(task.Result),CancellationToken.None,
                                  TaskContinuationOptions.ExecuteSynchronously |
                                  TaskContinuationOptions.OnlyOnRanToCompletion,
                                  scheUI);
