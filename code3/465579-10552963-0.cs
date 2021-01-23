    public class Sample2
    {
        public static class BoundPropertyNames
        {
            public static readonly string Foo = ((MemberExpression)((Expression<Func<Sample2, int>>)(s => s.Foo)).Body).Member.Name;
        }
     
        public int Foo { get; set; }
    }
