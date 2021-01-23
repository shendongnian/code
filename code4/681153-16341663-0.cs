    public struct IndexedValue<T>
    {
        private readonly T value;
        private readonly int index;
        public T Value { get { return value; } }
        public int Index { get { return index; } }
        public IndexedValue(T value, int index)
        {
            this.value = value;
            this.index = index;
        }
    }
    public static class Extensions
    {
        public static IEnumerable<IndexedValue<T>> WithIndex<T>
            (this IEnumerable<T> source)
        {
            return source.Select((value, index) => new IndexedValue<T>(value, index));
        }
    }
