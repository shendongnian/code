    public class Foo             
        {
            private IComparable  _inner { get; set; }
        
            public Foo(IComparable original)
            {
                _inner = original;
            }
        
            public bool IsGreaterThan(IComparable  comp)
            {
                return _inner.CompareTo(comp) > 0;
            }
    }
