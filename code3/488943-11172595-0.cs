    public static class Enumerables
    {
        public static IEnumerable<T> TopN<T, TV>(this IEnumerable<T> value, Func<T, TV> selector, Int32 count)
        {
            var comparer = Comparer<TV>.Default;
            var queue = new SortedList<TV, T>(count);
            foreach (var val in value)
            {
                var currTv = selector(val);
                if (queue.Count < count || comparer.Compare(currTv, queue.Keys[0]) > 0)
                {
                    if (queue.Count == count)
                        queue.RemoveAt(0);
                    queue.Add(currTv, val);
                }
            }
            return queue.Values;
        }
        public static IEnumerable<T> BottomN<T, TV>(this IEnumerable<T> value, Func<T, TV> selector, Int32 count)
        {
            var comparer = Comparer<TV>.Default;
            var queue = new SortedList<TV, T>(count);
            foreach (var val in value)
            {
                var currTv = selector(val);
                if (queue.Count < count || comparer.Compare(currTv, queue.Keys[queue.Count - 1]) < 0)
                {
                    if (queue.Count == count)
                        queue.RemoveAt(queue.Count - 1);
                    queue.Add(currTv, val);
                }
            }
            return queue.Values;
        }
    }
