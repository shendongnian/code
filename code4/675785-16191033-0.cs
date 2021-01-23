    /// <summary>A bounded blocking queue.</summary>
    /// <typeparam name="T">The element type of the queue, which must be a reference type.</typeparam>
    public sealed class BoundedBlockingQueue<T>: IDisposable where T: class
    {
        #region Construction and disposal
        /// <summary>Constructor.</summary>
        /// <param name="maxQueueSize">
        /// The maximum size of the queue.
        /// Calls to <see cref="Enqueue"/> when the queue is full will block until at least one item has been removed.
        /// Calls to <see cref="Dequeue"/> when the queue is empty will block until a new item is enqueued.
        /// </param>
        public BoundedBlockingQueue(int maxQueueSize)
        {
            if (maxQueueSize <= 0)
            {
                throw new ArgumentOutOfRangeException("maxQueueSize");
            }
            _queue                  = new Queue<T>(maxQueueSize);
            _itemsAvailable         = new Semaphore(0, maxQueueSize);
            _spaceAvailable         = new Semaphore(maxQueueSize, maxQueueSize);
            _queueStopped           = new ManualResetEvent(false);
            _queueStoppedAndEmpty   = new ManualResetEvent(false);
            _stoppedOrItemAvailable = new WaitHandle[] { _queueStopped, _itemsAvailable };
        }
        /// <summary>Disposal.</summary>
        public void Dispose()
        {
            if (_itemsAvailable != null)
            {
                _itemsAvailable.Close();
                _spaceAvailable.Close();
                _queueStopped.Close();
                _queueStoppedAndEmpty.Close();
                _itemsAvailable = null;          // Use _itemsAvailable as a flag to indicate that Dispose() has been called.
            }
        }
        #endregion Construction and disposal
        #region Public properties
        /// <summary>The number of items currently in the queue.</summary>
        public int Count
        {
            get
            {
                throwIfDisposed();
                lock (_queue)
                {
                    return _queue.Count;
                }
            }
        }
        /// <summary>Has <see cref="Stop"/> been called?</summary>
        public bool Stopped
        {
            get
            {
                throwIfDisposed();
                return _stopped;
            }
        }
        #endregion Public properties
        #region Public methods
        /// <summary>
        /// Signals that new items will no longer be placed into the queue.
        /// After this is called, calls to <see cref="Dequeue"/> will return null immediately if the queue is empty.
        /// Before this is called, calls to <see cref="Dequeue"/> will block if the queue is empty.
        /// Attempting to enqueue items after this has been called will cause an exception to be thrown.
        /// </summary>
        /// <remarks>
        /// If you use a different thread to enqueue items than the thread that calls Stop() you might get a race condition.
        /// 
        /// If the queue is full and a thread calls Enqueue(), that thread will block until space becomes available in the queue.
        /// If a different thread then calls Stop() while the other thread is blocked in Enqueue(), the item enqueued by the other
        /// thread may become lost since it will be enqueued after the special null value used to indiciate the end of the
        /// stream is enqueued.
        /// 
        /// To prevent this from happening, you must enqueue from the same thread that calls Stop(), or provide another
        /// synchronisation mechanism to avoid this race condition.
        /// </remarks>
        public void Stop()
        {
            throwIfDisposed();
            lock (_queue)
            {
                _queueStopped.Set();
                _stopped = true;
            }
        }
        /// <summary>
        /// Returns the front item of the queue without removing it, or null if the queue is currently empty.
        /// A null return does NOT indicate that <see cref="Stop"/> has been called.
        /// This never blocks.
        /// </summary>
        /// <returns>The front item of the queue, or null if the queue is empty.</returns>
        public T Peek()
        {
            throwIfDisposed();
            T result;
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    result = _queue.Peek();
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
        /// <summary>
        /// Enqueues a new non-null item.
        /// If there is no room in the queue, this will block until there is room.
        /// An exception will be thrown if <see cref="Stop"/> has been called.
        /// </summary>
        /// <param name="item">The item to be enqueued. This may not be null.</param>
        public void Enqueue(T item)
        {
            throwIfDisposed();
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (_stopped)
            {
                throw new InvalidOperationException("Attempting to enqueue an item to a stopped queue.");
            }
            this.enqueue(item);
        }
        /// <summary>
        /// Dequeues the next available item.
        /// If <see cref="Stop"/> has been called, this returns null if the queue is empty.
        /// Otherwise it blocks until an item becomes available (or <see cref="Stop"/> is called).
        /// </summary>
        /// <returns>The next available item, or null if the queue is empty and stopped.</returns>
        public T Dequeue()
        {
            throwIfDisposed();
            if (_isQueueStoppedAndEmpty)
            {
                return null;
            }
            WaitHandle.WaitAny(_stoppedOrItemAvailable);
            lock (_queue)
            {
                if (_stopped && (_queue.Count == 0))
                {
                    _isQueueStoppedAndEmpty = true;
                    _queueStoppedAndEmpty.Set();
                    return null;
                }
                else
                {
                    T item = _queue.Dequeue();
                    _spaceAvailable.Release();
                    return item;
                }
            }
        }
        /// <summary>Waits forever for the queue to become empty AND stopped.</summary>
        public void WaitUntilStoppedAndEmpty()
        {
            throwIfDisposed();
            WaitUntilStoppedAndEmpty(Timeout.Infinite);
        }
        /// <summary>Waits up to the specified time for the queue to become empty AND stopped.</summary>
        /// <param name="timeoutMilliseconds">The maximum wait time, in milliseconds.</param>
        /// <returns>True if the wait succeeded, false if it timed-out.</returns>
        public bool WaitUntilStoppedAndEmpty(int timeoutMilliseconds)
        {
            throwIfDisposed();
            return _queueStoppedAndEmpty.WaitOne(timeoutMilliseconds);
        }
        #endregion Public methods
        #region Private methods
        /// <summary>Enqueues a new item (which may be null to indicate the last item to go into the queue).</summary>
        /// <param name="item">An item to enqueue.</param>
        private void enqueue(T item)
        {
            _spaceAvailable.WaitOne();
            lock (_queue)
            {
                _queue.Enqueue(item);
            }
            _itemsAvailable.Release();
        }
        /// <summary>Throws if this object has been disposed.</summary>
        private void throwIfDisposed()
        {
            if (_itemsAvailable == null)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
        #endregion Private methods
        #region Fields
        /// <summary>
        /// Contains wait handles for "stopped" and "item available".
        /// Therefore using this for WaitAny() will wait until the queue is stopped
        /// or an item becomes available, whichever is the sooner.
        /// </summary>
        private readonly WaitHandle[] _stoppedOrItemAvailable;
        private Semaphore _itemsAvailable;
        private volatile bool _stopped;
        private volatile bool _isQueueStoppedAndEmpty;
        private readonly Queue<T> _queue;
        private readonly Semaphore _spaceAvailable;
        private readonly ManualResetEvent _queueStopped;
        private readonly ManualResetEvent _queueStoppedAndEmpty;
        #endregion Fields
    }
