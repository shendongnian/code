    static class Operators
    {
        public static T Multiply<T>(T x, T y)
        {
            return OperatorCache<T>.Multiply(x, y);
        }
        
        static class OperatorCache<T>
        {
            static OperatorCache()
            {
                Multiply = MakeBinaryOperator(ExpressionType.Multiply);
            }
            
            static Func<T, T, T> MakeBinaryOperator(ExpressionType type)
            {
                var x = Expression.Parameter(typeof(T), "x");
                var y = Expression.Parameter(typeof(T), "y");
                var body = Expression.MakeBinary(type, x, y);
                var expr = Expression.Lambda<Func<T, T, T>>(body, x, y);
                return expr.Compile();
            }
        
            public static Func<T, T, T> Multiply;
            
            
        }
    }
