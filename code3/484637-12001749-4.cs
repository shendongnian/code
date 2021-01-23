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
                    T someThing = default(T);
                    try
                    {
                       someThing = _actual.Current;
                    }
                    catch
                    {
                       throw new Exception();
                    }
                    return someThing; 
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
    
            [DebuggerHidden]
            public bool MoveNext()
            {
                    bool move = false;
                    try
                    {
                        move = _actual.MoveNext();
                    }
                    catch
                    {
                         throw new IndexOutOfRangeException();
                    }
                   return move;
            }
    
            public void Reset()
            {
                _actual.Reset();
            }
       }
