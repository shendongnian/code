    public abstract class Retriever<T> : IRetriever<T>
    {
        private readonly object locker;
        private readonly BlockingCollection<Uri> pending;
        private readonly Thread[] threads;
        private CancellationTokenSource cancellation;
        private volatile int isStarted;
        private volatile int isDisposing;
        public event EventHandler<RetrieverEventArgs<T>> Retrieved;
        protected Retriever(int concurrency)
        {
            if (concurrency <= 0)
            {
                throw new ArgumentOutOfRangeException("concurrency", "The specified concurrency level must be greater than zero.");
            }
            this.locker = new object();
            this.pending = new BlockingCollection<Uri>(new ConcurrentQueue<Uri>());
            this.threads = new Thread[concurrency];
            this.cancellation = new CancellationTokenSource();
            this.isStarted = 0;
            this.isDisposing = 0;
            this.InitializeThreads();
        }
        ~Retriever()
        {
            this.Dispose(false);
        }
        private void InitializeThreads()
        {
            for (int i = 0; i < this.threads.Length; i++)
            {
                Thread thread = new Thread(this.ProcessQueue)
                {
                    IsBackground = true
                };
                this.threads[i] = thread;
            }
        }
        private void StartThreads()
        {
            foreach (Thread thread in this.threads)
            {
                if (thread.ThreadState == ThreadState.Unstarted)
                {
                    thread.Start();
                }
            }
        }
        private void CancelOperations(bool reset)
        {
            this.cancellation.Cancel();
            this.cancellation.Dispose();
            if (reset)
            {
                this.cancellation = new CancellationTokenSource();
            }
        }
        private void WaitForThreadsToExit()
        {
            foreach (Thread thread in this.threads)
            {
                thread.Join();
            }
        }
        private void ProcessQueue()
        {
            while (this.isDisposing == 0)
            {
                while (this.isStarted == 0)
                {
                    Monitor.Wait(this.locker);
                }
                Uri location;
                try
                {
                    location = this.pending.Take(this.cancellation.Token);
                }
                catch (OperationCanceledException)
                {
                    continue;
                }
                T data;
                try
                {
                    data = this.Retrieve(location, this.cancellation.Token);
                }
                catch (OperationCanceledException)
                {
                    continue;
                }
                RetrieverEventArgs<T> args = new RetrieverEventArgs<T>(location, data);
                EventHandler<RetrieverEventArgs<T>> callback = this.Retrieved;
                if (!Object.ReferenceEquals(callback, null))
                {
                    callback(this, args);
                }
            }
        }
        private void ThowIfDisposed()
        {
            if (this.isDisposing == 1)
            {
                throw new ObjectDisposedException("Retriever");
            }
        }
        protected abstract T Retrieve(Uri location, CancellationToken token);
        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.CompareExchange(ref this.isDisposing, 1, 0) == 1)
            {
                return;
            }
            if (disposing)
            {
                this.CancelOperations(false);
                this.WaitForThreadsToExit();
                this.pending.Dispose();
            }
        }
        public void Start()
        {
            this.ThowIfDisposed();
            if (Interlocked.CompareExchange(ref this.isStarted, 1, 0) == 1)
            {
                throw new InvalidOperationException("The retriever is already started.");
            }
            Monitor.PulseAll(this.locker);
            this.StartThreads();
        }
        public void Add(Uri location)
        {
            this.pending.Add(location);
        }
        public void Stop()
        {
            this.ThowIfDisposed();
            if (Interlocked.CompareExchange(ref this.isStarted, 0, 1) == 0)
            {
                throw new InvalidOperationException("The retriever is already stopped.");
            }
            this.CancelOperations(true);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
