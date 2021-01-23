    public static class Utility<T> // Type argument on class
    {  
        public static IEnumerable<T> Filter1(
           this IEnumerable<T> input, Func<T, bool> predicate)  
        {  
