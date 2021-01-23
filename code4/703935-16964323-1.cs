    public abstract class AsyncTaskCodeActivity<T> : AsyncCodeActivity<T>
    {
        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            var task = ExecuteAsync(context);
            return AsyncFactory<T>.ToBegin(task, callback, state);
        }
        protected sealed override T EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            return AsyncFactory<T>.ToEnd(result);
        }
        protected abstract Task<T> ExecuteAsync(AsyncCodeActivityContext context);
    }
