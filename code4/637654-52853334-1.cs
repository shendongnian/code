    public static class AsyncEx
    {
        public static async Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> asyncAction, int maxDegreeOfParallelism = 10)
        {
            var semaphoreSlim = new SemaphoreSlim(maxDegreeOfParallelism);
            var tcs = new TaskCompletionSource<object>();
            var exceptions = new ConcurrentBag<Exception>();
            bool addingCompleted = false;
    
            foreach (T item in source)
            {
                await semaphoreSlim.WaitAsync();
                asyncAction(item).ContinueWith(t =>
                {
                    semaphoreSlim.Release();
    
                    if (t.Exception != null)
                    {
                        exceptions.Add(t.Exception);
                    }
    
                    if (Volatile.Read(ref addingCompleted) && semaphoreSlim.CurrentCount == maxDegreeOfParallelism)
                    {
                        if (exceptions.Count > 0)
                        {
                            tcs.SetException(new AggregateException(exceptions));
                        }
                        else
                        {
                            tcs.SetResult(null);
                        }
                    }
                });
            }
    
            Volatile.Write(ref addingCompleted, true);
            if (semaphoreSlim.CurrentCount < maxDegreeOfParallelism)
            {
                await tcs.Task;
            }
            else 
            {
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
