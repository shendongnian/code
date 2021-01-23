    partial class MoreObservables
    {
        /// <summary>
        /// Avoids backpressure by enqueuing items when the <paramref name="source"/> produces them more rapidly than the observer can process.
        /// </summary>
        /// <param name="source">The source sequence.</param>
        /// <param name="maxQueueSize">Maximum queue size. If the queue gets full, less recent items are discarded from the queue.</param>
        /// <param name="scheduler">Optional, default: <see cref="Scheduler.Default"/>: <see cref="IScheduler"/> on which to observe notifications.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxQueueSize"/> is negative.</exception>
        /// <remarks>
        /// A <paramref name="maxQueueSize"/> of 0 observes items only if the subscriber is ready.
        /// A <paramref name="maxQueueSize"/> of 1 guarantees to observe the last item in the sequence, if any.
        /// To observe the whole source sequence, specify <see cref="int.MaxValue"/>.
        /// </remarks>
        public static IObservable<TSource> Latest<TSource>(this IObservable<TSource> source, int maxQueueSize, IScheduler scheduler = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (maxQueueSize < 0) throw new ArgumentOutOfRangeException(nameof(maxQueueSize));
            if (scheduler == null) scheduler = Scheduler.Default;
            return Observable.Create<TSource>(observer => LatestImpl<TSource>.Subscribe(source, maxQueueSize, scheduler, observer));
        }
        private static class LatestImpl<TSource>
        {
            public static IDisposable Subscribe(IObservable<TSource> source, int maxQueueSize, IScheduler scheduler, IObserver<TSource> observer)
            {
                if (observer == null) throw new ArgumentNullException(nameof(observer));
                var longrunningScheduler = scheduler.AsLongRunning();
                if (longrunningScheduler != null)
                    return new LoopSubscription(source, maxQueueSize, longrunningScheduler, observer);
                return new RecursiveSubscription(source, maxQueueSize, scheduler, observer);
            }
            #region Subscriptions
            /// <summary>
            /// Represents a subscription to <see cref="Latest{TSource}(IObservable{TSource}, int, IScheduler)"/> which notifies in a loop.
            /// </summary>
            private sealed class LoopSubscription : IDisposable
            {
                private enum State
                {
                    Idle, // nothing to notify
                    Head, // next notification is in _head
                    Queue, // next notifications are in _queue, followed by _completion
                    Disposed, // disposed
                }
                private readonly SingleAssignmentDisposable _subscription = new SingleAssignmentDisposable();
                private readonly IObserver<TSource> _observer;
                private State _state;
                private TSource _head; // item in front of the queue
                private IQueue _queue; // queued items
                private Notification<TSource> _completion; // completion notification
                public LoopSubscription(IObservable<TSource> source, int maxQueueSize, ISchedulerLongRunning scheduler, IObserver<TSource> observer)
                {
                    _observer = observer;
                    _queue = Queue.Create(maxQueueSize);
                    scheduler.ScheduleLongRunning(_ => Loop());
                    _subscription.Disposable = source.Subscribe(
                        OnNext,
                        error => OnCompletion(Notification.CreateOnError<TSource>(error)),
                        () => OnCompletion(Notification.CreateOnCompleted<TSource>()));
                }
                private void OnNext(TSource value)
                {
                    lock (_subscription)
                    {
                        switch (_state)
                        {
                            case State.Idle:
                                _head = value;
                                _state = State.Head;
                                Monitor.Pulse(_subscription);
                                break;
                            case State.Head:
                            case State.Queue:
                                if (_completion != null) return;
                                try { _queue.Enqueue(value); }
                                catch (Exception error) // probably OutOfMemoryException
                                {
                                    _completion = Notification.CreateOnError<TSource>(error);
                                    _subscription.Dispose();
                                }
                                break;
                        }
                    }
                }
                private void OnCompletion(Notification<TSource> completion)
                {
                    lock (_subscription)
                    {
                        switch (_state)
                        {
                            case State.Idle:
                                _completion = completion;
                                _state = State.Queue;
                                Monitor.Pulse(_subscription);
                                _subscription.Dispose();
                                break;
                            case State.Head:
                            case State.Queue:
                                if (_completion != null) return;
                                _completion = completion;
                                _subscription.Dispose();
                                break;
                        }
                    }
                }
                public void Dispose()
                {
                    lock (_subscription)
                    {
                        if (_state == State.Disposed) return;
                        _head = default(TSource);
                        _queue = null;
                        _completion = null;
                        _state = State.Disposed;
                        Monitor.Pulse(_subscription);
                        _subscription.Dispose();
                    }
                }
                private void Loop()
                {
                    try
                    {
                        while (true) // overall loop for all notifications
                        {
                            // next notification to emit
                            Notification<TSource> completion;
                            TSource next; // iff completion == null
                            lock (_subscription)
                            {
                                while (true)
                                {
                                    while (_state == State.Idle)
                                        Monitor.Wait(_subscription);
                                    if (_state == State.Head)
                                    {
                                        completion = null;
                                        next = _head;
                                        _head = default(TSource);
                                        _state = State.Queue;
                                        break;
                                    }
                                    if (_state == State.Queue)
                                    {
                                        if (!_queue.IsEmpty)
                                        {
                                            completion = null;
                                            next = _queue.Dequeue(); // assumption: this never throws
                                            break;
                                        }
                                        if (_completion != null)
                                        {
                                            completion = _completion;
                                            next = default(TSource);
                                            break;
                                        }
                                        _state = State.Idle;
                                        continue;
                                    }
                                    Debug.Assert(_state == State.Disposed);
                                    return;
                                }
                            }
                            if (completion != null)
                            {
                                completion.Accept(_observer);
                                return;
                            }
                            _observer.OnNext(next);
                        }
                    }
                    finally { Dispose(); }
                }
            }
            /// <summary>
            /// Represents a subscription to <see cref="Latest{TSource}(IObservable{TSource}, int, IScheduler)"/> which notifies recursively.
            /// </summary>
            private sealed class RecursiveSubscription : IDisposable
            {
                private enum State
                {
                    Idle, // nothing to notify
                    Scheduled, // emitter scheduled or executing
                    Disposed, // disposed
                }
                private readonly SingleAssignmentDisposable _subscription = new SingleAssignmentDisposable();
                private readonly MultipleAssignmentDisposable _emitter = new MultipleAssignmentDisposable(); // scheduled emit action
                private readonly IScheduler _scheduler;
                private readonly IObserver<TSource> _observer;
                private State _state;
                private IQueue _queue; // queued items
                private Notification<TSource> _completion; // completion notification
                public RecursiveSubscription(IObservable<TSource> source, int maxQueueSize, IScheduler scheduler, IObserver<TSource> observer)
                {
                    _scheduler = scheduler;
                    _observer = observer;
                    _queue = Queue.Create(maxQueueSize);
                    _subscription.Disposable = source.Subscribe(
                        OnNext,
                        error => OnCompletion(Notification.CreateOnError<TSource>(error)),
                        () => OnCompletion(Notification.CreateOnCompleted<TSource>()));
                }
                private void OnNext(TSource value)
                {
                    lock (_subscription)
                    {
                        switch (_state)
                        {
                            case State.Idle:
                                _emitter.Disposable = _scheduler.Schedule(value, EmitNext);
                                _state = State.Scheduled;
                                break;
                            case State.Scheduled:
                                if (_completion != null) return;
                                try { _queue.Enqueue(value); }
                                catch (Exception error) // probably OutOfMemoryException
                                {
                                    _completion = Notification.CreateOnError<TSource>(error);
                                    _subscription.Dispose();
                                }
                                break;
                        }
                    }
                }
                private void OnCompletion(Notification<TSource> completion)
                {
                    lock (_subscription)
                    {
                        switch (_state)
                        {
                            case State.Idle:
                                _completion = completion;
                                _emitter.Disposable = _scheduler.Schedule(() => EmitCompletion(completion));
                                _state = State.Scheduled;
                                _subscription.Dispose();
                                break;
                            case State.Scheduled:
                                if (_completion != null) return;
                                _completion = completion;
                                _subscription.Dispose();
                                break;
                        }
                    }
                }
                public void Dispose()
                {
                    lock (_subscription)
                    {
                        if (_state == State.Disposed) return;
                        _emitter.Dispose();
                        _queue = null;
                        _completion = null;
                        _state = State.Disposed;
                        _subscription.Dispose();
                    }
                }
                private void EmitNext(TSource value, Action<TSource> self)
                {
                    try { _observer.OnNext(value); }
                    catch { Dispose(); return; }
                    lock (_subscription)
                    {
                        if (_state == State.Disposed) return;
                        Debug.Assert(_state == State.Scheduled);
                        if (!_queue.IsEmpty)
                            self(_queue.Dequeue());
                        else if (_completion != null)
                            _emitter.Disposable = _scheduler.Schedule(() => EmitCompletion(_completion));
                        else
                            _state = State.Idle;
                    }
                }
                private void EmitCompletion(Notification<TSource> completion)
                {
                    try { completion.Accept(_observer); }
                    finally { Dispose(); }
                }
            }
            #endregion
            #region IQueue
            /// <summary>
            /// FIFO queue that discards least recent items if size limit is reached.
            /// </summary>
            private interface IQueue
            {
                bool IsEmpty { get; }
                void Enqueue(TSource item);
                TSource Dequeue();
            }
            /// <summary>
            /// <see cref="IQueue"/> implementations.
            /// </summary>
            private static class Queue
            {
                public static IQueue Create(int maxSize)
                {
                    switch (maxSize)
                    {
                        case 0: return Zero.Instance;
                        case 1: return new One();
                        default: return new Many(maxSize);
                    }
                }
                private sealed class Zero : IQueue
                {
                    public static Zero Instance { get; } = new Zero();
                    private Zero() { }
                    public bool IsEmpty => true;
                    public void Enqueue(TSource item) { }
                    public TSource Dequeue() { throw new InvalidOperationException(); }
                }
                private sealed class One : IQueue
                {
                    private TSource _item;
                    public bool IsEmpty { get; private set; } = true;
                    public void Enqueue(TSource item)
                    {
                        _item = item;
                        IsEmpty = false;
                    }
                    public TSource Dequeue()
                    {
                        if (IsEmpty) throw new NotImplementedException();
                        var item = _item;
                        _item = default(TSource);
                        IsEmpty = true;
                        return item;
                    }
                }
                private sealed class Many : IQueue
                {
                    private readonly int _maxSize, _initialSize;
                    private int _deq, _enq; // indices of deque and enqueu positions
                    private TSource[] _buffer;
                    public Many(int maxSize)
                    {
                        if (maxSize < 2) throw new ArgumentOutOfRangeException(nameof(maxSize));
                        _maxSize = maxSize;
                        if (maxSize == int.MaxValue)
                            _initialSize = 4;
                        else
                        {
                            // choose an initial size that won't get us too close to maxSize when doubling
                            _initialSize = maxSize;
                            while (_initialSize >= 7)
                                _initialSize = (_initialSize + 1) / 2;
                        }
                    }
                    public bool IsEmpty { get; private set; } = true;
                    public void Enqueue(TSource item)
                    {
                        if (IsEmpty)
                        {
                            if (_buffer == null) _buffer = new TSource[_initialSize];
                            _buffer[0] = item;
                            _deq = 0;
                            _enq = 1;
                            IsEmpty = false;
                            return;
                        }
                        if (_deq == _enq) // full
                        {
                            if (_buffer.Length == _maxSize) // overwrite least recent
                            {
                                _buffer[_enq] = item;
                                if (++_enq == _buffer.Length) _enq = 0;
                                _deq = _enq;
                                return;
                            }
                            // increse buffer size
                            var newSize = _buffer.Length >= _maxSize / 2 ? _maxSize : 2 * _buffer.Length;
                            var newBuffer = new TSource[newSize];
                            var count = _buffer.Length - _deq;
                            Array.Copy(_buffer, _deq, newBuffer, 0, count);
                            Array.Copy(_buffer, 0, newBuffer, count, _deq);
                            _deq = 0;
                            _enq = _buffer.Length;
                            _buffer = newBuffer;
                        }
                        _buffer[_enq] = item;
                        if (++_enq == _buffer.Length) _enq = 0;
                    }
                    public TSource Dequeue()
                    {
                        if (IsEmpty) throw new NotImplementedException();
                        var result = ReadAndClear(ref _buffer[_deq]);
                        if (++_deq == _buffer.Length) _deq = 0;
                        if (_deq == _enq)
                        {
                            IsEmpty = true;
                            if (_buffer.Length > _initialSize) _buffer = null;
                        }
                        return result;
                    }
                    private static TSource ReadAndClear(ref TSource item)
                    {
                        var result = item;
                        item = default(TSource);
                        return result;
                    }
                }
            }
            #endregion
        }
    }
