    public static class NullableExt
    {
        public static TResult? ApplyFunction<T, TResult>(this T? nullable, Func<T, TResult> function)
            where T: struct
            where TResult: struct
        {
            if (nullable.HasValue)
                return function(nullable.Value);
            else
                return new TResult?();
        }
    }
