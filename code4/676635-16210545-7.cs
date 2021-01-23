    public sealed class ParallelWorkProcessor<T> where T: class // T is the work item type.
    {
        public delegate T    Read();           // Called by only one thread.
        public delegate T    Process(T block); // Called simultaneously by multiple threads.
        public delegate void Write(T block);   // Called by only one thread.
        public ParallelWorkProcessor(Read read, Process process, Write write, int numWorkers = 0)
        {
            _read    = read;
            _process = process;
            _write   = write;
            numWorkers = (numWorkers > 0) ? numWorkers : Environment.ProcessorCount;
            _workPool    = new SemaphoreSlim(numWorkers*2);
            _inputQueue  = new BlockingCollection<WorkItem>(numWorkers);
            _outputQueue = new ConcurrentPriorityQueue<int, T>();
            _workers     = new Task[numWorkers];
            startWorkers();
            Task.Factory.StartNew(enqueueWorkItems);
            _multiplexor = Task.Factory.StartNew(multiplex);
        }
        private void startWorkers()
        {
            for (int i = 0; i < _workers.Length; ++i)
            {
                _workers[i] = Task.Factory.StartNew(processBlocks);
            }
        }
        private void enqueueWorkItems()
        {
            int index = 0;
            while (true)
            {
                T data = _read();
                if (data == null) // Signals end of input.
                {
                    _inputQueue.CompleteAdding();
                    _outputQueue.Enqueue(index, null); // Special sentinel WorkItem .
                    break;
                }
                _workPool.Wait();
                _inputQueue.Add(new WorkItem(data, index++));
            }
        }
        private void multiplex()
        {
            int index = 0; // Next required index.
            int last = int.MaxValue;
            while (index != last)
            {
                KeyValuePair<int, T> workItem;
                _outputQueue.WaitForNewItem(); // There will always be at least one item - the sentinel item.
                while ((index != last) && _outputQueue.TryPeek(out workItem))
                {
                    if (workItem.Value == null) // The sentinel item has a null value to indicate that it's the sentinel.
                    {
                        last = workItem.Key;  // The sentinel's key is the index of the last block + 1.
                    }
                    else if (workItem.Key == index) // Is this block the next one that we want?
                    {
                        // Even if new items are added to the queue while we're here, the new items will be lower priority.
                        // Therefore it is safe to assume that the item we will dequeue now is the same one we peeked at.
                        _outputQueue.TryDequeue(out workItem);
                        Contract.Assume(workItem.Key == index); // This *must* be the case.
                        _workPool.Release();                    // Allow the enqueuer to queue another work item.
                        _write(workItem.Value);
                        ++index;
                    }
                    else // If it's not the block we want, we know we'll get a new item at some point.
                    {
                        _outputQueue.WaitForNewItem();
                    }
                }
            }
        }
        private void processBlocks()
        {
            foreach (var block in _inputQueue.GetConsumingEnumerable())
            {
                var processedData = _process(block.Data);
                _outputQueue.Enqueue(block.Index, processedData);
            }
        }
        public bool WaitForFinished(int maxMillisecondsToWait) // Can be Timeout.Infinite.
        {
            return _multiplexor.Wait(maxMillisecondsToWait);
        }
        private sealed class WorkItem
        {
            public WorkItem(T data, int index)
            {
                Data  = data;
                Index = index;
            }
            public T   Data  { get; private set; }
            public int Index { get; private set; }
        }
        private readonly Task[] _workers;
        private readonly Task _multiplexor;
        private readonly SemaphoreSlim _workPool;
        private readonly BlockingCollection<WorkItem> _inputQueue;
        private readonly ConcurrentPriorityQueue<int, T> _outputQueue;
        private readonly Read    _read;
        private readonly Process _process;
        private readonly Write   _write;
    }
