    public class FooComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var lhs = x as Foo;
            var rhs = y as Foo;
            return lhs != null && rhs != null && 
                   lhs.Bar.Equals(rhs.Bar) && lhs.Bar2.Equals(rhs.Bar2) ? 0 : 1;
        }
    }
