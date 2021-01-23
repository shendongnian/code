    public class InfiniteEnumerableWrapper<T> : IInfiniteEnumerable<T> {
        IEnumerable<T> _enumerable;
        public InfiniteEnumerableWrapper(IEnumerable<T> enumerable) {
            _enumerable = enumerable;
        }
        public IEnumerator<T> GetEnumerator() {
            return _enumerable.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return _enumerable.GetEnumerator();
        }
    }
