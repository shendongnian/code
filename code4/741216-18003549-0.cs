    class CompareFooByBar : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.Bar == y.Bar;
        }
    
        public int GetHashCode(Foo x)
        {
            return  x.Bar.GetHashCode();
        }
    }
