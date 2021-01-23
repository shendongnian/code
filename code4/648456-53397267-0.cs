        public static IEnumerable<List<T>> TimedBatch<T>(this IEnumerable<T> collection, double timeoutMilliseconds, long maxItems)
        {
            object _lock = new object();
            List<T> batch = new List<T>();
            AutoResetEvent yieldEventTriggered = new AutoResetEvent(false);
            AutoResetEvent yieldEventFinished = new AutoResetEvent(false);
            bool yieldEventTriggering = false; 
            var task = Task.Run(delegate
            {
                foreach (T item in collection)
                {
                    lock (_lock)
                    {
                        batch.Add(item);
                        if (batch.Count == maxItems)
                        {
                            yieldEventTriggering = true;
                            yieldEventTriggered.Set();
                        }
                    }
                    if (yieldEventTriggering)
                    {
                        yieldEventFinished.WaitOne(); //wait for the yield to finish, and batch to be cleaned 
                        yieldEventTriggering = false;
                    }
                }
            });
            while (!task.IsCompleted)
            {
                //Wait for the event to be triggered, or the timeout to finish
                yieldEventTriggered.WaitOne(TimeSpan.FromMilliseconds(timeoutMilliseconds));
                lock (_lock)
                {
                    if (batch.Count > 0) //yield return only if the batch accumulated something
                    {
                        yield return batch;
                        batch.Clear();
                        yieldEventFinished.Set();
                    }
                }
            }
            task.Wait();
        }
