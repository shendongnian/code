    public class ConcurrentPriorityQueue<T> : IProducerConsumerCollection<T>
    {
        private object key = new object();
        private SortedSet<Tuple<T, int>> set = new SortedSet<Tuple<T, int>>(new Comparer<T>());
        private Func<T, int> prioritySelector;
        public ConcurrentPriorityQueue(Func<T, int> prioritySelector)
        {
            this.prioritySelector = prioritySelector;
        }
        private class Comparer<T> : IComparer<Tuple<T, int>>
        {
            public int Compare(Tuple<T, int> first, Tuple<T, int> second)
            {
                return first.Item2.CompareTo(second.Item2);
            }
        }
        public bool TryAdd(T item)
        {
            lock (key)
            {
                return set.Add(Tuple.Create(item, prioritySelector(item)));
            }
        }
        public bool TryTake(out T item)
        {
            lock (key)
            {
                if (set.Count > 0)
                {
                    var first = set.First();
                    item = first.Item1;
                    return set.Remove(first);
                }
                else
                {
                    item = default(T);
                    return false;
                }
            }
        }
        public bool ChangePriority(T item, int oldPriority, int newPriority)
        {
            lock (key)
            {
                if (set.Remove(Tuple.Create(item, oldPriority)))
                {
                    return set.Add(Tuple.Create(item, newPriority));
                }
                else
                    return false;
            }
        }
        public bool ChangePriority(T item)
        {
            lock (key)
            {
                var result = set.FirstOrDefault(pair => object.Equals(pair.Item1, item));
                if (object.Equals(result.Item1, item))
                {
                    return ChangePriority(item, result.Item2, prioritySelector(item));
                }
                else
                {
                    return false;
                }
            }
        }
        public void CopyTo(T[] array, int index)
        {
            lock (key)
            {
                foreach (var item in set.Select(pair => pair.Item1))
                {
                    array[index++] = item;
                }
            }
        }
        public T[] ToArray()
        {
            lock (key)
            {
                return set.Select(pair => pair.Item1).ToArray();
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ToArray().AsEnumerable().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            lock (key)
            {
                foreach (var item in set.Select(pair => pair.Item1))
                {
                    array.SetValue(item, index++);
                }
            }
        }
        public int Count
        {
            get { lock (key) { return set.Count; } }
        }
        public bool IsSynchronized
        {
            get { return true; }
        }
        public object SyncRoot
        {
            get { return key; }
        }
    }
