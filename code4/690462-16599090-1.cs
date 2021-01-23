    class FooComparer : IEqualityComparer<Foo>
    {
        public bool  Equals(Foo x, Foo y)
        {
            if ( x == null )
            {
                return y == null ;
            }
            else if ( y == null ) return false ;
            else
            {
                return x.Equals(y) ;
            }
        }
        
        public int  GetHashCode(Foo obj)
        {
            return obj.GetHashCode() ;
        }
    }
