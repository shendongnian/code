    public class Subset<T> : IReadOnlyList<T>
    {
        private IList<T> source;
        private int startIndex;
        private int endIndex;
        public Subset(IList<T> source, int startIndex, int endIndex)
        {
            this.source = source;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }
    
        public T this[int i]
        {
            get
            {
                if (startIndex + i >= endIndex)
                    throw new IndexOutOfRangeException();
                return source[startIndex + i];
            }
        }
    
        public int Count
        {
            get { return endIndex - startIndex; }
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return source.Skip(startIndex)
                .Take(endIndex - startIndex)
                .GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
