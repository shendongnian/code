    public class ConcurrentBagComplete<T> : ConcurrentBag<T>
    {
        public void AddRange(IEnumerable<T> collection)
        {
            Parallel.ForEach(collection, item =>
            {
                base.Add(item);
            });
        }
    }
