    public class QueuedItem<TInput, TResult>
    {
        private readonly object _lockObject = new object();
        private TResult _result;
        private readonly TInput _input;
        private readonly TResult _notfinished;
        internal readonly bool IsEndQueue = false;
        internal QueuedItem()
        {
            IsEndQueue = true;
        }
        public QueuedItem(TInput input, TResult notfinished)
        {
            _input = input;
            _notfinished = notfinished;
            _result = _notfinished;
        }
        public TResult ReadResult()
        {
            lock (_lockObject)
            {
                if (!IsResultReady)
                    throw new InvalidOperationException("Check IsResultReady before calling ReadResult()");
                return _result;
            }
        }
        public void WriteResult(TResult value)
        {
            lock (_lockObject)
            {
                if (IsResultReady)
                    throw new InvalidOperationException("Result has already been written");
                _result = value;
            }
        }
        public TInput Input { get { return _input; } }
        public bool IsResultReady
        {
            get
            {
                lock (_lockObject)
                {
                    return !object.Equals(_result, _notfinished) || IsEndQueue;
                }
            }
        }
    }
    public class ParallelImmediateOrderedProcessingQueue<TInput, TResult>
    {
        private readonly ReaderWriterLockSlim _addLock = new ReaderWriterLockSlim();
        private readonly object _readingResultsLock = new object();
        private readonly ConcurrentQueue<QueuedItem<TInput, TResult>> _concurrentQueue = new ConcurrentQueue<QueuedItem<TInput, TResult>>();
        bool _isFinishedAdding = false;
        private readonly TResult _notFinished;
        private readonly Action<QueuedItem<TInput, TResult>> _processor;
        /// <param name="notFinished">A value that indicates the result is not yet finished</param>
        /// <param name="processor">Must call SetResult() on argument when finished.</param>
        public ParallelImmediateOrderedProcessingQueue(TResult notFinished, Action<QueuedItem<TInput, TResult>> processor)
        {
            _notFinished = notFinished;
            _processor = processor;
        }
        public event Action ResultsReady = delegate { };
        private void SignalResult()
        {
                QueuedItem<TInput, TResult> item;
                if (_concurrentQueue.TryPeek(out item) && item.IsResultReady)
                {
                    ResultsReady();
                }
        }
        public void Add(TInput input)
        {
            bool shouldThrow = false;
            _addLock.EnterReadLock();
            {
                shouldThrow = _isFinishedAdding;
                if (!shouldThrow)
                {
                    var queuedItem = new QueuedItem<TInput, TResult>(input, _notFinished);
                    _concurrentQueue.Enqueue(queuedItem);
                    Task.Factory.StartNew(() => { _processor(queuedItem); SignalResult(); });
                }
            }
            _addLock.ExitReadLock();
            if (shouldThrow)
                throw new InvalidOperationException("An attempt was made to add an item, but adding items was marked as completed");
        }
        public IEnumerable<TResult> ConsumeReadyResults()
        {
            //lock necessary to preserve ordering
            lock (_readingResultsLock)
            {
                QueuedItem<TInput, TResult> queuedItem;
                while (_concurrentQueue.TryPeek(out queuedItem) && queuedItem.IsResultReady)
                {
                    if (!_concurrentQueue.TryDequeue(out queuedItem))
                        throw new ApplicationException("this shouldn't happen");
                    if (queuedItem.IsEndQueue)
                    {
                        _completion.SetResult(true);
                    }
                    else
                    {
                        yield return queuedItem.ReadResult();
                    }
                }
            }
        }
        public void CompleteAddingItems()
        {
            _addLock.EnterWriteLock();
            {
                _isFinishedAdding = true;
                var queueCompletion = new QueuedItem<TInput, TResult>();
                _concurrentQueue.Enqueue(queueCompletion);
                Task.Factory.StartNew(() => { SignalResult(); });
            }
            _addLock.ExitWriteLock();
        }
        TaskCompletionSource<bool> _completion = new TaskCompletionSource<bool>();
        public void WaitForCompletion()
        {
            _completion.Task.Wait();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int notFinished = int.MinValue;
            var processingQueue = new ParallelImmediateOrderedProcessingQueue<int, int>(notFinished, qi =>
            {
                int work = 0;
                Console.WriteLine("Working on " + qi.Input);
                //simulate work
                int maxBusy = 90000000 - (10 * (qi.Input % 3));
                for (int busy = 0; busy <= maxBusy; ++busy) { ++work; };
                Console.WriteLine("Finished " + qi.Input);
                qi.WriteResult(qi.Input);
            });
            processingQueue.ResultsReady += new Action(() =>
            {
                Task.Factory.StartNew(() =>
                    {
                        foreach (int result in processingQueue.ConsumeReadyResults())
                        {
                            Console.WriteLine("Results Available: " + result);
                        }
                    });
            });
            int iterations = new Random().Next(5, 50);
            Console.WriteLine("------- iterations: " + iterations + "-------");
            for (int i = 1; i <= iterations; ++i)
            {
                processingQueue.Add(i);
            }
            while (true)
            {
                char c = Console.ReadKey().KeyChar;
                if (c == 's')
                {
                    break;
                }
                else
                {
                    ++iterations;
                    Console.WriteLine("adding: " + iterations);
                    processingQueue.Add(iterations);
                }
            }
            processingQueue.CompleteAddingItems();
            processingQueue.WaitForCompletion();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
