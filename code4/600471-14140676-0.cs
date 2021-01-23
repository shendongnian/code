    ParallelForReplicatingTask task2 = new ParallelForReplicatingTask(parallelOptions, delegate {
                        for (int k = Interlocked.Increment(ref actionIndex); k <= actionsCopy.Length; k = Interlocked.Increment(ref actionIndex))
                        {
                                actionsCopy[k - 1]();
                        }
                    }, TaskCreationOptions.None, InternalTaskOptions.SelfReplicating);
    task2.RunSynchronously(parallelOptions.EffectiveTaskScheduler);
    task2.Wait();
