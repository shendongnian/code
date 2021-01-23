        public static void IgnoreUnobservedExceptions(this Task task)
        {
            if (task.IsCompleted)
            {
                if (task.IsFaulted)
                {
                    var dummy = task.Exception;
                }
                return;
            }
            task.ContinueWith(t =>
                {
                    var dummy = t.Exception;
                }, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
        }
