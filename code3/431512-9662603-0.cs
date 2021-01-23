    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static IEnumerable<MyClass> WhereYearTotal(this IEnuerable<MyClass> source, DateTime date)
            {
                return source.Where(i => i.Timestamp <= date.ToUniversalTime() && i.Timestamp >= yearStart.ToUniversalTime())
            }
        }   
    }
