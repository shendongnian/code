    class CompareFooToBar : IEqualityComparer<Foo>
    {
        Bar bar;
        public CompareFooToBar(Bar bar) { this.bar = bar;}
        public bool Equals(Foo x, Foo y)
        {
            // hack - ignore y completely, assuming Contains pass element as x
            return x.Bar == bar; 
        }
    
        public int GetHashCode(Foo x) 
        {
            return  0;
        }
    }
    foos.Contains(null, new CompareFooToBar(bar))
