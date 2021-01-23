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
            return Observable.Create<TSource>(observer => new LatestImpl<TSource>.Subscription(source, maxQueueSize, scheduler, observer));
        }
        private static class LatestImpl<TSource>
        {
            /// <summary>
            /// Notification to be emitted to an observer.
            /// </summary>
            private sealed class Notification
            {
                /// <summary>
                /// Singleton with <see cref="Kind"/> <see cref="NotificationKind.OnCompleted"/>.
                /// </summary>
                public static Notification Completed { get; } = new Notification(true);
                /// <summary>
                /// Singleton with <see cref="Kind"/> null, meaning disposed.
                /// </summary>
                public static Notification Disposed { get; } = new Notification(false);
                private readonly Func<Notification> _acknowledge;
                /// <summary>
                /// Null means disposal.
                /// </summary>
                public NotificationKind? Kind { get; }
                /// <summary>
                /// Only available if <see cref="Kind"/> is <see cref="NotificationKind.OnNext"/>.
                /// </summary>
                public TSource Value { get; }
                /// <summary>
                /// Only available if <see cref="Kind"/> is <see cref="NotificationKind.OnError"/>.
                /// </summary>
                public Exception Exception { get; }
                /// <summary>
                /// Only available if <see cref="Kind"/> is <see cref="NotificationKind.OnNext"/>.
                /// </summary>
                /// <returns>The next notification or null, if none is currently available.</returns>
                public Notification Acknowldge() => _acknowledge();
                /// <summary>
                /// Create a <see cref="NotificationKind.OnNext"/> notification.
                /// </summary>
                public Notification(TSource value, Func<Notification> acknowledge)
                {
                    Kind = NotificationKind.OnNext;
                    Value = value;
                    _acknowledge = acknowledge;
                }
                /// <summary>
                /// Create a <see cref="NotificationKind.OnError"/> notification.
                /// </summary>
                public Notification(Exception error)
                {
                    Kind = NotificationKind.OnError;
                    Exception = Exception;
                }
                private Notification(bool completed)
                {
                    if (!completed) return;
                    Kind = NotificationKind.OnCompleted;
                }
                /// <summary>
                /// Emit the notification to the specified observer.
                /// </summary>
                public void Accept(IObserver<TSource> observer)
                {
                    if (Kind == null) return;
                    switch (Kind.Value)
                    {
                        case NotificationKind.OnNext:
                            observer.OnNext(Value);
                            break;
                        case NotificationKind.OnError:
                            observer.OnError(Exception);
                            break;
                        case NotificationKind.OnCompleted:
                            observer.OnCompleted();
                            break;
                    }
                }
            }
            #region IEmitter
            private interface IEmitter
            {
                void Emit(Notification notification);
            }
            private static class Emitter
            {
                public static IEmitter Create(IObserver<TSource> observer, IScheduler scheduler)
                {
                    var longrunning = scheduler.AsLongRunning();
                    if (longrunning != null) return new LongRunningEmitter(observer, longrunning);
                    return new RecursiveEmitter(observer, scheduler);
                }
                /// <summary>
                /// <see cref="IEmitter"/> that notifies on a long running scheduler.
                /// </summary>
                private sealed class LongRunningEmitter : IEmitter
                {
                    private readonly IObserver<TSource> _observer;
                    private AutoResetEvent _gate = new AutoResetEvent(false);
                    private Notification _next;
                    public LongRunningEmitter(IObserver<TSource> observer, ISchedulerLongRunning scheduler)
                    {
                        _observer = observer;
                        scheduler.ScheduleLongRunning(_ => Loop());
                    }
                    public void Emit(Notification notification)
                    {
                        _next = notification;
                        _gate.Set();
                    }
                    private void Loop()
                    {
                        while (true)
                        {
                            _gate.WaitOne();
                            var current = _next;
                            _next = null;
                            do
                            {
                                current.Accept(_observer);
                                if (current.Kind != NotificationKind.OnNext)
                                {
                                    _gate.Dispose();
                                    return;
                                }
                                current = current.Acknowldge();
                            } while (current != null);
                        }
                    }
                }
                /// <summary>
                /// <see cref="IEmitter"/> that notifies recursively on a scheduler.
                /// </summary>
                private sealed class RecursiveEmitter : IEmitter
                {
                    private readonly IObserver<TSource> _observer;
                    private readonly IScheduler _scheduler;
                    public RecursiveEmitter(IObserver<TSource> observer, IScheduler scheduler)
                    {
                        _observer = observer;
                        _scheduler = scheduler;
                    }
                    public void Emit(Notification notification)
                    {
                        if (notification.Kind == null) return;
                        _scheduler.Schedule(notification, LoopRec);
                    }
                    private void LoopRec(Notification notification, Action<Notification> self)
                    {
                        notification.Accept(_observer);
                        if (notification.Kind != NotificationKind.OnNext) return;
                        notification = notification.Acknowldge();
                        if (notification == null || notification.Kind == null) return;
                        self(notification);
                    }
                }
            }
            #endregion
            #region IQueue
            /// <summary>
            /// FIFO queue with size limit.
            /// </summary>
            private interface IQueue
            {
                /// <summary>
                /// Gets whether the queue is empty.
                /// </summary>
                bool IsEmpty { get; }
                /// <summary>
                /// Enqueue an item, possibly discarding the least recent item to keep the count within the limit.
                /// </summary>
                void Enqueue(TSource item);
                /// <summary>
                /// Dequeue an item.
                /// </summary>
                /// <exception cref="InvalidOperationException">Queue is empty.</exception>
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
            /// <summary>
            /// Represents a subscription to <see cref="Latest{TSource}(IObservable{TSource}, int, IScheduler)"/>.
            /// </summary>
            public sealed class Subscription : IDisposable
            {
                private readonly SingleAssignmentDisposable _subscription = new SingleAssignmentDisposable(); // subscription to the source
                private readonly IEmitter _emitter;
                private IQueue _queue;
                private Notification _completion;
                private bool _isEmitting;
                public Subscription(IObservable<TSource> source, int maxQueueSize, IScheduler scheduler, IObserver<TSource> observer)
                {
                    _emitter = Emitter.Create(observer, scheduler);
                    _queue = Queue.Create(maxQueueSize);
                    _subscription.Disposable = source.Subscribe(
                        OnNext,
                        error => OnCompletion(new Notification(error)),
                        () => OnCompletion(Notification.Completed));
                }
                private void OnNext(TSource value)
                {
                    lock (_subscription)
                    {
                        if (_subscription.IsDisposed) return;
                        if (_isEmitting)
                        {
                            try { _queue.Enqueue(value); }
                            catch (Exception error) { _completion = new Notification(error); }
                            return;
                        }
                        _isEmitting = true;
                    }
                    _emitter.Emit(new Notification(value, Acknowledge));
                }
                private void OnCompletion(Notification completion)
                {
                    lock (_subscription)
                    {
                        if (_subscription.IsDisposed) return;
                        _subscription.Dispose();
                        if (_isEmitting)
                        {
                            _completion = completion;
                            return;
                        }
                        _queue = null;
                        _isEmitting = true;
                    }
                    _emitter.Emit(completion);
                }
                public void Dispose()
                {
                    lock (_subscription)
                    {
                        if (_queue == null) return;
                        _subscription.Dispose();
                        _queue = null;
                        _completion = null;
                        if (_isEmitting) return;
                        _isEmitting = true;
                    }
                    _emitter.Emit(Notification.Disposed);
                }
                private Notification Acknowledge()
                {
                    lock (_subscription)
                    {
                        if (_queue == null)
                            return Notification.Disposed;
                        if (!_queue.IsEmpty)
                            return new Notification(_queue.Dequeue(), Acknowledge);
                        if (_completion != null)
                        {
                            var completion = _completion;
                            _queue = null;
                            _completion = null;
                            return completion;
                        }
                        _isEmitting = false;
                        return null;
                    }
                }
            }
        }
    }
