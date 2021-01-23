    public class ImmediateOrderedPartitioner<T> : OrderablePartitioner<T>
    {
        private readonly IEnumerable<T> _consumingEnumerable;
        private readonly Ordering _ordering = new Ordering();
        public ImmediateOrderedPartitioner(BlockingCollection<T> collection) : base(true, true, true)
        {
            _consumingEnumerable = collection.GetConsumingEnumerable();
        }
        private class Ordering
        {
            public int Order = -1;
        }
        private class MyEnumerator<S> : IEnumerator<KeyValuePair<long, S>>
        {
            private readonly object _orderLock = new object();
            private readonly IEnumerable<S> _enumerable;
            private KeyValuePair<long, S> _current;
            private bool _hasItem;
            private Ordering _ordering;
            public MyEnumerator(IEnumerable<S> consumingEnumerable, Ordering ordering)
            {
                _enumerable = consumingEnumerable;
                _ordering = ordering;
            }
            public KeyValuePair<long, S> Current
            {
                get
                {
                    if (_hasItem)
                    {
                        return _current;
                    }
                    else
                        throw new InvalidOperationException();
                }
            }
            public void Dispose()
            {
                
            }
            object System.Collections.IEnumerator.Current
            {
                get 
                {
                    return Current;
                }
            }
            public bool MoveNext()
            {
                lock (_orderLock)
                {
                    bool canMoveNext = false;
                    var next = _enumerable.Take(1).FirstOrDefault(s => { canMoveNext = true; return true; });
                    if (canMoveNext)
                    {
                        _current = new KeyValuePair<long, S>(++_ordering.Order, next);
                        _hasItem = true;
                        ++_ordering.Order;
                    }
                    else
                    {
                        _hasItem = false;
                    }
                    return canMoveNext;
                }
            }
            public void Reset()
            {
                throw new NotSupportedException();
            }
        }
        public override IList<IEnumerator<KeyValuePair<long, T>>> GetOrderablePartitions(int partitionCount)
        {
            var result = new List<IEnumerator<KeyValuePair<long,T>>>();
            //for (int i = 0; i < partitionCount; ++i)
            //{
            //    result.Add(new MyEnumerator<T>(_consumingEnumerable, _ordering));
            //}
            //share the enumerator between partitions in this case to maintain
            //the proper locking on ordering.
            var enumerator = new MyEnumerator<T>(_consumingEnumerable, _ordering);
            for (int i = 0; i < partitionCount; ++i)
            {
                result.Add(enumerator);
            }
            return result;
        }
        public override bool SupportsDynamicPartitions
        {
            get
            {
                return false;
            }
        }
        public override IEnumerable<T> GetDynamicPartitions()
        {
            throw new NotImplementedException();
            return base.GetDynamicPartitions();
        }
        public override IEnumerable<KeyValuePair<long, T>> GetOrderableDynamicPartitions()
        {
            throw new NotImplementedException();
            return base.GetOrderableDynamicPartitions();
        }
        public override IList<IEnumerator<T>> GetPartitions(int partitionCount)
        {
            throw new NotImplementedException();
            return base.GetPartitions(partitionCount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<int> itemsQueue = new BlockingCollection<int>();
            var partitioner = new ImmediateOrderedPartitioner<int>(itemsQueue);
            Random random = new Random();
            var results = partitioner
            .AsParallel()
            .AsOrdered()
            .WithMergeOptions(ParallelMergeOptions.NotBuffered)
            //.WithDegreeOfParallelism(1)
            .Select(i =>
            {
                int work = 0;
                Console.WriteLine("Working on " + i);
                for (int busy = 0; busy <= 90000000; ++busy) { ++work; };
                Console.WriteLine("Finished " + i);
                return i;
            });
            TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();
            Task.Factory.StartNew(() =>
            {
                foreach (int i in results)
                {
                    Console.WriteLine("Result Available: " + i);
                }
                completion.SetResult(true);
            });
            int iterations;
            iterations = 1; // random.Next(5, 50);
            Console.WriteLine("------- iterations: " + iterations + "-------");
            for (int i = 1; i <= iterations; ++i)
            {
                itemsQueue.Add(i);
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
                    itemsQueue.Add(iterations);
                }
            }
            itemsQueue.CompleteAdding();
            completion.Task.Wait();
            Console.WriteLine("Done!");
            Console.ReadKey();
            itemsQueue.Dispose();
        }
    }
