    public class FooComparer : IEqualityComparer<Foo>
    {
        // Products are equal if their names and product numbers are equal.
        public bool Equals(Foo x, Foo y)
        {
    
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            return x.ID == y.ID
        }
    }
    
    list.Distinct(new FooComparer());
