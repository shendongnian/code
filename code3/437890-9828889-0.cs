    public class FooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Foo obj)
        {
            return obj.Id.GetHashCode();
        }
    }
