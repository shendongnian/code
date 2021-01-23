    public class Foo<T> 
        where T : IComparable
    {
        private T _inner { get; set; }
    
        public Foo(T original)
        {
            _inner = original;
        }
    
        public bool IsGreaterThan<T>(T comp)
        {
            return _inner.CompareTo(comp) > 0;
        }
    }
