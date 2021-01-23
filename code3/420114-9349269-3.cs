    class SomeClassEqualityComparer : IEqualityComparer<SomeClass>
    {
        private static readonly SomeClassEqualityComparer _instance = new SomeClassEqualityComparer();
        public bool Equals(SomeClass x, SomeClass y)
        {
            return x.param1 == y.param1 && x.param2 == y.param2;
        }
        public int GetHashCode(SomeClass obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.param1.GetHashCode();
                hash = hash * 23 + obj.param2.GetHashCode();
                return hash;
            }
        }
        public static IEqualityComparer<SomeClass> Instance
        {
            get { return _instance; }
        }
    }
