    private async void ProcessPrioritizedAndBatchedTasks()
    {
        bool continueProcessing = true;
        while (!_disposeCancellation.IsCancellationRequested && continueProcessing)
        {
            try
            {
                // Note that we're processing tasks on this thread
                _taskProcessingThread.Value = true;
                // Until there are no more tasks to process
                while (!_disposeCancellation.IsCancellationRequested)
                {
                    // Try to get the next task.  If there aren't any more, we're done.
                    Task targetTask;
                    lock (_nonthreadsafeTaskQueue)
                    {
                        if (_nonthreadsafeTaskQueue.Count == 0) break;
                        targetTask = _nonthreadsafeTaskQueue.Dequeue();
                    }
                    // If the task is null, it's a placeholder for a task in the round-robin queues.
                    // Find the next one that should be processed.
                    QueuedTaskSchedulerQueue queueForTargetTask = null;
                    if (targetTask == null)
                    {
                        lock (_queueGroups) FindNextTask_NeedsLock(out targetTask, out queueForTargetTask);
                    }
                    // Now if we finally have a task, run it.  If the task
                    // was associated with one of the round-robin schedulers, we need to use it
                    // as a thunk to execute its task.
                    if (targetTask != null)
                    {
                        if (queueForTargetTask != null) queueForTargetTask.ExecuteTask(targetTask);
                        else TryExecuteTask(targetTask);
                        // ***** MODIFIED CODE START ****
                        if (_awaitWrappedTasks)
                        {
                            var targetTaskType = targetTask.GetType();
                            if (targetTaskType.IsConstructedGenericType && typeof(Task).IsAssignableFrom(targetTaskType.GetGenericArguments()[0]))
                            {
                                dynamic targetTaskDynamic = targetTask;
                                // Here we await the completion of the proxy task.
                                // We do not await the proxy task directly, because that would result in that await will throw the exception of the wrapped task (if one existed)
                                // In the continuation we then simply return the value of the exception object so that the exception (stored in the proxy task) does not go totally unobserved (that could cause the process to crash)
                                await TaskExtensions.Unwrap(targetTaskDynamic).ContinueWith((Func<Task, Exception>)(t => t.Exception), TaskContinuationOptions.ExecuteSynchronously);
                            }
                        }
                        // ***** MODIFIED CODE END ****
                    }
                }
            }
            finally
            {
                // Now that we think we're done, verify that there really is
                // no more work to do.  If there's not, highlight
                // that we're now less parallel than we were a moment ago.
                lock (_nonthreadsafeTaskQueue)
                {
                    if (_nonthreadsafeTaskQueue.Count == 0)
                    {
                        _delegatesQueuedOrRunning--;
                        continueProcessing = false;
                        _taskProcessingThread.Value = false;
                    }
                }
            }
        }
    }
        
