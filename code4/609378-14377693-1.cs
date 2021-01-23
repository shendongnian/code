    class EmptyGrouping<K, E> : IGrouping<K, E> {
        public K Key { get; set; }
        public IEnumerator<E> GetEnumerator() {
            return Enumerable.Empty<E>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator(); 
        }
    }
