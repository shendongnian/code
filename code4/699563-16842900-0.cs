    public static class Functions<T>
    {
        public static readonly Func<T, T> Identity = x => x;
        public static readonly Func<T, T> DefaultValue => x => default(T);
        public static readonly Func<T, string> ToString = x => x == null ? null : x.ToString();
        ...
    }
