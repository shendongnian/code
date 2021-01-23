    public static class Utility 
    {  
        public static IEnumerable<T> Filter1<T>( // Type argument on the function
           this IEnumerable<T> input, Func<T, bool> predicate)  
        {  
