    public interface IMyList<T> : IEnumerable<T>
    {
        void Add(T item);
        void AddRange(IEnumerable<T> itemList);
    }
