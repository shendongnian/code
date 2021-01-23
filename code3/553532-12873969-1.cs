    public class FooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.Id == y.Id; // assuming that there's a value type like ID as key
        }
    
        public int GetHashCode(Foo obj)
        {
            return obj.Id.GetHashCode();
        }
    }
