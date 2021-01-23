        var response = RunTaskWithTimeout<ReturnType>(
            (Func<ReturnType>)delegate { return SomeMethod(someInput); }, 30);
        /// <summary>
        /// Generic method to run a task on a background thread with a specific timeout, if the task fails,
        /// notifies a user
        /// </summary>
        /// <typeparam name="T">Return type of function</typeparam>
        /// <param name="TaskAction">Function delegate for task to perform</param>
        /// <param name="TimeoutSeconds">Time to allow before task times out</param>
        /// <returns></returns>
        private T RunTaskWithTimeout<T>(Func<T> TaskAction, int TimeoutSeconds)
        {
            Task<T> backgroundTask;
            try
            {
                backgroundTask = Task.Factory.StartNew(TaskAction);
                backgroundTask.Wait(new TimeSpan(0, 0, TimeoutSeconds));
            }
            catch (AggregateException ex)
            {
                // task failed
                var failMessage = ex.Flatten().InnerException.Message);
                return default(T);
            }
            catch (Exception ex)
            {
                // task failed
                var failMessage = ex.Message;
                return default(T);
            }
            if (!backgroundTask.IsCompleted)
            {
                // task timed out
                return default(T);
            }
            // task succeeded
            return backgroundTask.Result;
        }
