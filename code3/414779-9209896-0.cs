    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace WindowsFormsApplication1
    {
        public static class GenericFilterExtension
        {
            public static IQueryable<T> DynamicWhere<T,U>(this IQueryable<T> input, string field, ExpressionType binaryOperator, U value)
            {
                var param = Expression.Parameter(typeof(T), "n");
    
                var op = Expression.MakeBinary(binaryOperator, Expression.Property(param, field), Expression.Constant(value));
    
                var exp = (Expression<Func<T, bool>>)Expression.Lambda(op, new ParameterExpression[] { param });
    
                return input.Where(exp);
            }
    
            public static IEnumerable<T> DynamicWhere<T, U>(this IEnumerable<T> input, string field, ExpressionType binaryOperator, U value)
            {
                var param = Expression.Parameter(typeof(T), "n");
    
                var op = Expression.MakeBinary(binaryOperator, Expression.Property(param, field), Expression.Constant(value));
    
                var exp = (Func<T, bool>)Expression.Lambda(op, new ParameterExpression[] { param }).Compile();
    
                return input.Where(exp);
            }
        }
    }
