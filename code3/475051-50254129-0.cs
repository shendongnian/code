		/// <summary>
        /// Concurrently Executes async actions for each item of <see cref="IEnumerable<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type of IEnumerable</typeparam>
        /// <param name="enumerable">instance of <see cref="IEnumerable<typeparamref name="T"/>"/></param>
        /// <param name="action">an async <see cref="Action" /> to execute</param>
        /// <param name="maxActionsToRunInParallel">Optional, max numbers of the actions to run in parallel</param>
        /// <returns>A Task representing an async operation</returns>
        public static async Task ForEachAsyncConcurrent<T>(
            this IEnumerable<T> enumerable,
            Func<T, Task> action,
            int? maxActionsToRunInParallel = null)
        {
            if (maxActionsToRunInParallel.HasValue)
            {
                var tasks = enumerable.Select(item => action(item)).ToList();
                using (var throttler = new SemaphoreSlim(maxActionsToRunInParallel.Value, maxActionsToRunInParallel.Value))
                {
                    var tasksWithThrottler = new List<Task>();
                    // Have each task notify the throttler when it completes so that it decrements the number of tasks currently running.
                    tasks.ForEach(t => tasksWithThrottler.Add(t.ContinueWith(tsk => throttler.Release())));
                    // Start running each task.
                    foreach (var task in tasks)
                    {
                        // Increment the number of tasks currently running and wait if too many are running.
                        await throttler.WaitAsync();
                        task.Start();
                    }
                    // Wait for all of the provided tasks to complete.
                    // We wait on the list of tasksWithThrottler instead of the original tasks,
                    //      otherwise there is a potential race condition where the throttler's
                    //      using block is exited before some Tasks have had their ContinueWith action completed,
                    //      which references the throttler, resulting in an exception due to accessing a disposed object.
                    await Task.WhenAll(tasksWithThrottler.ToArray());
                }
            }
            else
            {
                await Task.WhenAll(enumerable.Select(item => action(item)));
            }
        }
