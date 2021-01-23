    public interface IConcurrentBag<T> : IProducerConsumerCollection<T>
    {
        void Add(T item);
        bool TryPeek(out T result);
        bool IsEmpty { get; }
    }
