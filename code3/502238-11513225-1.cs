    private class SimpleGrouping<T, U> : IGrouping<T, U>
    {
        private T key;
        private IEnumerable<U> grouping;
        T IGrouping<T, U>.Key
        {
            get { return key; }
        }
        IEnumerator<U> IEnumerable<U>.GetEnumerator()
        {
            return grouping.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return grouping.GetEnumerator();
        }
        public SimpleGrouping(T k, IEnumerable<U> g)
        {
            this.key = k;
            this.grouping = g;
        }
    }
