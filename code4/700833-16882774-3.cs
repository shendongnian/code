    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    using ConsoleApplication1;
    namespace Demo
    {
        public sealed class ParallelBlockProcessor<T> where T: class
        {
            public delegate T Read();            // Called by only one thread.
            public delegate T Process(T block);  // Called simultaneously by multiple threads.
            public delegate void Write(T block); // Called by only one thread.
            public ParallelBlockProcessor(Read read, Process process, Write write, int numTasks = 0)
            {
                Contract.Requires(read != null);
                Contract.Requires(process != null);
                Contract.Requires(write != null);
                Contract.Requires((0 <= numTasks) && (numTasks <= 64));
                _read    = read;
                _process = process;
                _write   = write;
                numTasks = (numTasks > 0) ? numTasks : Environment.ProcessorCount;
                _workPool   = new BlockingCollection<WorkItem>(numTasks*2);
                _inputQueue  = new BlockingCollection<WorkItem>(numTasks);
                _outputQueue = new ConcurrentPriorityQueue<int, T>();
                _processors  = new Task[numTasks];
                initWorkItems();
                startProcessors();
                Task.Factory.StartNew(enqueueBlocks);
                _dequeuer = Task.Factory.StartNew(dequeueBlocks);
            }
            private void startProcessors()
            {
                for (int i = 0; i < _processors.Length; ++i)
                {
                    _processors[i] = Task.Factory.StartNew(processBlocks);
                }
            }
            private void initWorkItems()
            {
                for (int i = 0; i < _workPool.BoundedCapacity; ++i)
                {
                    _workPool.Add(new WorkItem());
                }
            }
            private void enqueueBlocks()
            {
                int index = 0;
                while (true)
                {
                    T data = _read();
                    if (data == null)
                    {
                        _inputQueue.CompleteAdding();
                        _outputQueue.Enqueue(index, null); // Special terminator WorkItem.
                        break;
                    }
                    WorkItem workItem = _workPool.Take();
                    workItem.Data = data;
                    workItem.Index = index++;
                    _inputQueue.Add(workItem);
                }
            }
            private void dequeueBlocks()
            {
                int index = 0; // Next required index.
                int last = int.MaxValue;
                while (true)
                {
                    KeyValuePair<int, T> workItem;
                    _outputQueue.WaitForNewItem();   // There will always be at least one item - the sentinel item.
                    while (_outputQueue.TryPeek(out workItem))
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
                            Contract.Assume(workItem.Key == index);
                            _workPool.Add(new WorkItem()); // Free up a work pool item.     
                            _write(workItem.Value);
                            ++index;
                        }
                        else // If it's not the block we want, we know we'll get a new item at some point.
                        {
                            _outputQueue.WaitForNewItem();
                        }
                        if (index == last)
                        {
                            return;
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
                return _dequeuer.Wait(maxMillisecondsToWait);
            }
            private sealed class WorkItem // Note: This is mutable.
            {
                public T   Data  { get; set; }
                public int Index { get; set; }
            }
            private readonly Task[] _processors;
            private readonly Task _dequeuer;
            private readonly BlockingCollection<WorkItem> _workPool;
            private readonly BlockingCollection<WorkItem> _inputQueue;
            private readonly ConcurrentPriorityQueue<int, T> _outputQueue;
            private readonly Read    _read;
            private readonly Process _process;
            private readonly Write   _write;
        }
    }
