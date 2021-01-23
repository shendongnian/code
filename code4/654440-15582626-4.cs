    public static class Ext
    {
        public static Task<TResult> FromAsync<TArg1, TArg2, TArg3, TArg4, TResult>(
            this TaskFactory<TResult> factory,
            Func<TArg1,TArg2,TArg3,TArg4,AsyncCallback, object, IAsyncResult> beginMethod, 
            Func<IAsyncResult, TResult> endMethod, 
            TArg1 arg1,
            TArg2 arg2,
            TArg3 arg3,
            TArg4 arg4,
            object state,
            TaskCreationOptions creationOptions = TaskCreationOptions.None, 
            TaskScheduler scheduler = null)
        {
            scheduler = scheduler ?? TaskScheduler.Current;
            AsyncCallback callback = null;
            if (beginMethod == null)
            {
                throw new ArgumentNullException("beginMethod");
            }
            if (endMethod == null)
            {
                throw new ArgumentNullException("endMethod");
            }
            TaskCompletionSource<TResult> tcs = 
                 new TaskCompletionSource<TResult>(state, creationOptions);
            try
            {
                if (callback == null)
                {
                    callback = delegate (IAsyncResult iar) 
                    {
                        tcs.TrySetResult(endMethod(iar));
                    };
                }
                beginMethod(arg1, arg2, arg3, arg4, callback, state);
            }
            catch
            {
                tcs.TrySetResult(default(TResult));
                throw;
            }
            return tcs.Task;
        } 
    }
