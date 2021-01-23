    public class MyFooComparer : IComparer<Foo>
    {
        private readonly Dictionary<Type, int> _pattern;
        public MyFooComparer(IEnumerable<Foo> pattern)
        {
            _pattern = new Dictionary<Type, int>();
            int i = 0;
            foreach (var foo in pattern)
            {
                _pattern.Add(foo.GetType(), i);
                i++;
            }
        }
    
        public int Compare(Foo x, Foo y)
        {
            var xVal = _pattern[x.GetType()];
            var yVal = _pattern[y.GetType()];
            return xVal.CompareTo(yVal);
        }
    }
