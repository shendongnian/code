    public FooByNameEqualityComparer : IEqualityComparer<Foo>
    {
        public int GetHashCode(Foo foo)
        {
            return foo.Name.GetHashCode();
        }
        public bool Equals(Foo x, Foo y)
        {
            return x.Name == y.Name;
        }
    }
    ...
    Dictionary<Foo, int> map = new Dictionary<Foo, int>(new FooByNameComparer());
