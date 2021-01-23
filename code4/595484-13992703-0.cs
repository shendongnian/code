    public class InfiniteSequence : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new InfiniteEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        class InfiniteEnumerator : IEnumerator<int>
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }
            public bool MoveNext()
            {
                Current++;
                return true;
            }
            public void Reset()
            {
                Current = 0;
            }
            public int Current { get; private set; }
            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
