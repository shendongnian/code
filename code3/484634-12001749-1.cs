    public class HiddenEnumerator<T> : IEnumerable<T>, IEnumerator<T>
        {
            IEnumerator<T> _actual;
            private HiddenEnumerator(IEnumerable<T> enu)
            {
                _actual = enu.GetEnumerator();
            }
    
            public static HiddenEnumerator<T> Enumerable(IEnumerable<T> enu )
            {
                return new HiddenEnumerator<T>(enu);
            }
            public T Current
            {
                [DebuggerHidden]
                get 
                { 
                    return _actual.Current;
                }
            }
         
            public IEnumerator<T> GetEnumerator()
            {
                return this;
            }
       
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
     
            public void Dispose()
            {
                _actual.Dispose();
            }
    
            object IEnumerator.Current
            {
                get { return _actual.Current; }
            }
    
            public bool MoveNext()
            {
                return _actual.MoveNext();
            }
    
            public void Reset()
            {
                _actual.Reset();
            }
       }
