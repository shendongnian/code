    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    
    namespace LinqKit
    {
        public static class PredicateBuilder
        {
            public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2);
            public static Expression<Func<T, bool>> False<T>();
            public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2);
            public static Expression<Func<T, bool>> True<T>();
        }
    }
