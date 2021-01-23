    public static class Utility<T> // Type argument on class
    {  
        public static IEnumerable<T> Filter1( // No longer an extension method
           IEnumerable<T> input, Func<T, bool> predicate)  
        {  
