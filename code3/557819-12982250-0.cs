    public class MessedUpIterator<T> : IEnumerable<T>, IEnumerator
    {
        private IEnumerable<T> source;
        private IEnumerator enumerator;
    
        private IEnumerator MyEnumerator
        {
            get
            {
                return enumerator ?? source.GetEnumerator();
            }
        }
    
        public MessedUpIterator(IEnumerable<T> source)
        {
            this.source = source;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return source.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return source.GetEnumerator();
        }
    
        object IEnumerator.Current
        {
            get { return MyEnumerator.Current; }
        }
    
        bool IEnumerator.MoveNext()
        {
            return MyEnumerator.MoveNext();
        }
    
        void IEnumerator.Reset()
        {
            MyEnumerator.Reset();
        }
    }
