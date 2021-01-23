    public class FooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.Bar.Equals(y.Bar) && x.Bar2.Equals(y.Bar2);
        }
        public int GetHashCode(Foo obj)
        {
            unchecked
            {
                var hash = 13;
                hash = (hash * 7) + obj.Bar.GetHashCode();
                hash = (hash * 7) + obj.Bar2.GetHashCode();
                return hash;
            }
        }
    }
