    public static class CollectionMixins
    {
        private class ReadOnlyListProjection<U,T> : IReadOnlyList<T>
        {
            public Func<U,T> Selector { get; private set; }
            public IList<U> List { get; private set; }
            public ReadOnlyListProjection(IList<U> list, Func<U, T> selector)
            {
                List = list;
                Selector = selector;
            }
            public T this[int index]
            {
                get { return Selector(List[index]);  }
            }
            public int Count
            {
                get { return List.Count; }
            }
            public IEnumerator<T> GetEnumerator()
            {
                return List.Select(Selector).GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return List.Select(Selector).GetEnumerator();
            }
        }
        public static IReadOnlyList<T> ProjectReadOnly<U, T>(this IList<U> This, Func<U, T> fn)
        {
            return new ReadOnlyListProjection<U, T>(This, fn);
        }
    }
