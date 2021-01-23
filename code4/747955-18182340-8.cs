    public static class Cast<T, U>
    {
        public static readonly Func<T, U> Do;
        static Cast()
        {
            var par1 = Expression.Parameter(typeof(T));
            Do = Expression.Lambda<Func<T, U>>(Expression.Convert(par1, typeof(U)), par1).Compile();
        }
    }
 
