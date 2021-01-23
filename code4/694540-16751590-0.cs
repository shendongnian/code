<pre>
    public class InfiniteEnumerable<T> : IEnumerable<T>
    {
        private static InfiniteEnumerable<T> val;
        public static InfiniteEnumerable<T> Value { get { return val; } }
        public IEnumerator<T> GetEnumerator()
        {
            throw new InvalidOperationException(
                "This enumerable cannot be enumerated");
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new InvalidOperationException(
                 "This enumerable cannot be enumerated");
        }
    }
    // Sample usage.
    IEnumerable<int> enumerable = GetEnumerable();
    if (enumerable == InfiniteEnumerable<int>.Value)
    {
        // This is 'infinite' enumerable.
    }
    else
    {
        // enumerate it here.
    }
</pre>
