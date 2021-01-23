    public static class Functions
    {
        public static Func<T> Of<T>(Func<T> input)
        {
            return input;
        }
    
        public static Func<T1, TResult> Of<T1, TResult>
            (Func<T1, TResult> input)
        {
            return input;
        }
    
        public static Func<T1, T2, TResult> Of<T1, T2, TResult>
            (Func<T1, T2, TResult> input)
        {
            return input;
        }
    }
