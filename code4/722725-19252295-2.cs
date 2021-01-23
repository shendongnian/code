    internal class FakeTaskRunner : ITaskRunner
    {
        public Task<TNewResult> Execute<TResult, TNewResult>(Func<TResult> action, Func<Task<TResult>, TNewResult> continueWith)
        {
            Task<TResult> task = new Task<TResult>(action);
            try
            {
                task.RunSynchronously();
                if (task.Exception != null)
                    throw task.Exception;
                return task.ContinueWith(continueWith);
            }
            catch (Exception ex)
            {
                throw ((AggregateException)ex).InnerExceptions[0];
            }
        }
    }
