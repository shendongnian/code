    public class AsyncQueue<T>
    {
        private readonly ConcurrentQueue<T> queue;
        private readonly ConcurrentQueue<DequeueAsyncResult> dequeueQueue; 
    
        private class DequeueAsyncResult : IAsyncResult
        {
            public bool IsCompleted { get; set; }
            public WaitHandle AsyncWaitHandle { get; set; }
            public object AsyncState { get; set; }
            public bool CompletedSynchronously { get; set; }
            public T Result { get; set; }
    
            public AsyncCallback Callback { get; set; }
        }
    
        public AsyncQueue()
        {
            dequeueQueue = new ConcurrentQueue<DequeueAsyncResult>();
            queue = new ConcurrentQueue<T>();
        }
    
        public void Enqueue(T item)
        {
            DequeueAsyncResult asyncResult;
            while  (dequeueQueue.TryDequeue(out asyncResult))
            {
                if (!asyncResult.IsCompleted)
                {
                    asyncResult.IsCompleted = true;
                    asyncResult.Result = item;
    
                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        if (asyncResult.Callback != null)
                        {
                            asyncResult.Callback(asyncResult);
                        }
                        else
                        {
                            ((EventWaitHandle) asyncResult.AsyncWaitHandle).Set();
                        }
                    });
                    return;
                }
            }
            queue.Enqueue(item);
        }
    
        public IAsyncResult BeginDequeue(int timeout, AsyncCallback callback, object state)
        {
            T result;
            if (queue.TryDequeue(out result))
            {
                var dequeueAsyncResult = new DequeueAsyncResult
                {
                    IsCompleted = true, 
                    AsyncWaitHandle = new EventWaitHandle(true, EventResetMode.ManualReset), 
                    AsyncState = state, 
                    CompletedSynchronously = true, 
                    Result = result
                };
                if (null != callback)
                {
                    callback(dequeueAsyncResult);
                }
                return dequeueAsyncResult;
            }
    
            var pendingResult = new DequeueAsyncResult
            {
                AsyncState = state, 
                IsCompleted = false, 
                AsyncWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset), 
                CompletedSynchronously = false,
                Callback = callback
            };
            dequeueQueue.Enqueue(pendingResult);
            Timer t = null;
            t = new Timer(_ =>
            {
                if (!pendingResult.IsCompleted)
                {
                    pendingResult.IsCompleted = true;
                    if (null != callback)
                    {
                        callback(pendingResult);
                    }
                    else
                    {
                        ((EventWaitHandle)pendingResult.AsyncWaitHandle).Set();
                    }
                }
                t.Dispose();
            }, new object(), timeout, Timeout.Infinite);
    
            return pendingResult;
        }
    
        public T EndDequeue(IAsyncResult result)
        {
            var dequeueResult = (DequeueAsyncResult) result;
            return dequeueResult.Result;
        }
    }
