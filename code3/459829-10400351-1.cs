    public interface IReadOnlyList<out T> : IEnumerable<T>
    {
        int Count { get; }
        T this[int index] { get; }
    }
