    public abstract class AsyncTaskCodeActivity<T> : AsyncCodeActivity<T>
    {
        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            var cts = new CancellationTokenSource();
            context.UserState = cts;
            var task = ExecuteAsync(context, cts.Token);
            return AsyncFactory<T>.ToBegin(task, callback, state);
        }
        protected sealed override T EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            try
            {
                return AsyncFactory<T>.ToEnd(result);
            }
            catch (OperationCanceledException)
            {
                if (context.IsCancellationRequested)
                    context.MarkCanceled();
                else
                    throw;
                return default(T); // or throw?
            }
        }
        protected override void Cancel(AsyncCodeActivityContext context)
        {
            var cts = (CancellationTokenSource)context.UserState;
            cts.Cancel();
        }
        protected abstract Task<T> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken);
    }
