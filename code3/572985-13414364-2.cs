    private void ThreadBasedDispatchLoop(Action threadInit, Action threadFinally)
    {
        _taskProcessingThread.Value = true;
        if (threadInit != null) threadInit();
        try
        {
            // If the scheduler is disposed, the cancellation token will be set and
            // we'll receive an OperationCanceledException.  That OCE should not crash the process.
            try
            {
                // If a thread abort occurs, we'll try to reset it and continue running.
                while (true)
                {
                    try
                    {
                        // For each task queued to the scheduler, try to execute it.
                        foreach (var task in _blockingTaskQueue.GetConsumingEnumerable(_disposeCancellation.Token))
                        {
                            Task targetTask = task;
                            // If the task is not null, that means it was queued to this scheduler directly.
                            // Run it.
                            if (targetTask != null)
                            {
                                TryExecuteTask(targetTask);
                            }
                            // If the task is null, that means it's just a placeholder for a task
                            // queued to one of the subschedulers.  Find the next task based on
                            // priority and fairness and run it.
                            else
                            {
                                // Find the next task based on our ordering rules...                                    
                                QueuedTaskSchedulerQueue queueForTargetTask;
                                lock (_queueGroups) FindNextTask_NeedsLock(out targetTask, out queueForTargetTask);
                                // ... and if we found one, run it
                                if (targetTask != null) queueForTargetTask.ExecuteTask(targetTask);
                            }
                            if (_awaitWrappedTasks)
                            {
                                var targetTaskType = targetTask.GetType();
                                if (targetTaskType.IsConstructedGenericType && typeof(Task).IsAssignableFrom(targetTaskType.GetGenericArguments()[0]))
                                {
                                    dynamic targetTaskDynamic = targetTask;
                                    // Here we wait for the completion of the proxy task.
                                    // We do not wait for the proxy task directly, because that would result in that Wait() will throw the exception of the wrapped task (if one existed)
                                    // In the continuation we then simply return the value of the exception object so that the exception (stored in the proxy task) does not go totally unobserved (that could cause the process to crash)
                                    TaskExtensions.Unwrap(targetTaskDynamic).ContinueWith((Func<Task, Exception>)(t => t.Exception), TaskContinuationOptions.ExecuteSynchronously).Wait();
                                }
                            }
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        // If we received a thread abort, and that thread abort was due to shutting down
                        // or unloading, let it pass through.  Otherwise, reset the abort so we can
                        // continue processing work items.
                        if (!Environment.HasShutdownStarted && !AppDomain.CurrentDomain.IsFinalizingForUnload())
                        {
                            Thread.ResetAbort();
                        }
                    }
                }
            }
            catch (OperationCanceledException) { }
        }
        finally
        {
            // Run a cleanup routine if there was one
            if (threadFinally != null) threadFinally();
            _taskProcessingThread.Value = false;
        }
    }
