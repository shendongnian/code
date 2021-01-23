    public static class LazyExtensions
    {
        public static IEnumerable<IGrouping<TKey, TElement>> GroupConsecutive<TKey, TElement>(
            this IEnumerable<TElement> source, Func<TElement, TKey> keySelector)
        {
            if (!source.Any())
                yield break;
            var comparer = Comparer<TKey>.Default;
            Grouping<TKey, TElement> group = null;
            foreach (var item in source)
            {
                var key = keySelector(item);
                if (group == null)
                    group = new Grouping<TKey, TElement>(key);
                if (comparer.Compare(group.Key, key) != 0)
                {
                    yield return group;
                    group = new Grouping<TKey, TElement>(key);
                }
                group.Elements.Add(item);
            }
            yield return group;
        }
        private class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
        {
            public Grouping(TKey key)
            {
                Key = key;
                Elements = new List<TElement>();
            }
            public List<TElement> Elements { get; private set; }
            public TKey Key { get; private set; }
            public IEnumerator<TElement> GetEnumerator()
            {
                return Elements.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
