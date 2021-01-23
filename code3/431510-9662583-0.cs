    static class MyHelper
    {
        public static IEnumerable<T> WhereYearTotal(this IEnumerable<T> input, DateTime d)
        {
             return input.Where( ... )
        }
    }
    // usage : (the namespace for MyHelper must be in your using list)
    myCollection.WhereYearTotal( DateTime.Now );
