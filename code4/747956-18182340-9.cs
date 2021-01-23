    public static class Multiply<T>
    {
        public static readonly Func<T, T, T> Do;
        static Multiply()
        {
            var par1 = Expression.Parameter(typeof(T));
            var par2 = Expression.Parameter(typeof(T));
            Do = Expression.Lambda<Func<T, T, T>>(Expression.Multiply(par1, par2), par1, par2).Compile();
        }
    }
