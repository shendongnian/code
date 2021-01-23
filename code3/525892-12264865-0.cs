    public class MyFooComparer : IComparer<Foo>
    {
        private readonly Dictionary<Type, int> _patern;
        public MyFooComparer(IEnumerable<Foo> patern)
        {
            _patern = new Dictionary<Type, int>();
            int i = 0;
            foreach (var foo in patern)
            {
                _patern.Add(foo.GetType(), i);
                i++;
            }
        }
    
        public int Compare(Foo x, Foo y)
        {
            var xVal = _patern[x.GetType()];
            var yVal = _patern[y.GetType()];
            return xVal.CompareTo(yVal);
        }
    }
