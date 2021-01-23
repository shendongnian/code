    public class SortedTupleBag<TKey, TValue> : SortedSet<Tuple<TKey, TValue>>
    {
        private class TupleComparer : Comparer<Tuple<TKey, TValue>>
        {
            public override int Compare(Tuple<TKey, TValue> x, Tuple<TKey, TValue> y)
            {
                if (x == null || y == null) return 0;
                // If the keys are the same we don't care about the order.
                // Return 1 so that duplicates are not ignored.
                return x.Item1.Equals(y.Item1)
                    ? 1
                    : Comparer<TKey>.Default.Compare(x.Item1, y.Item1);
            }
        }
        public SortedTupleBag() : base(new TupleComparer()) { }
        public void Add(TKey key, TValue value)
        {
            Add(new Tuple<TKey, TValue>(key, value));
        }
    }
