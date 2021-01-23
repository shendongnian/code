    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace DroopyExtensions
    {
        public static class CircularEnumaratorExtensionMethod
        {
    
            public static IEnumerator<T> GetCircularEnumerator<T>(this IEnumerable<T> t) 
            {
                return new CircularEnumarator<T>(t.GetEnumerator());
            }
    
            private class CircularEnumarator<T> : IEnumerator<T>
            {
                private readonly IEnumerator _wrapedEnumerator;
    
                public CircularEnumarator(IEnumerator wrapedEnumerator)
                {
                    this._wrapedEnumerator = wrapedEnumerator;
                }
    
                public object Current => _wrapedEnumerator.Current;
    
                T IEnumerator<T>.Current =>  (T)Current;
    
                public void Dispose()
                {
                    
                }
    
                public bool MoveNext()
                {
                    if (!_wrapedEnumerator.MoveNext())
                    {
                        _wrapedEnumerator.Reset();
                        return _wrapedEnumerator.MoveNext();
                    }
                    return true;
                }
    
                public void Reset()
                {
                    _wrapedEnumerator.Reset();
                }
            }
        }   
    } 
