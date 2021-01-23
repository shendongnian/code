    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace WindowsFormsApplication1
    {
        public static class GenericFilterExtension
        {
            public static IQueryable<TRow> DynamicWhere<TRow,TColumn>(this IQueryable<TRow> input, string field, ExpressionType binaryOperator, TColumn value)
            {
                var exp = (Expression<Func<TRow, bool>>)MakeWhereLambda<TRow, TColumn>(field, binaryOperator, value);
    
                return input.Where(exp);
            }
    
            public static IEnumerable<TRow> DynamicWhere<TRow, TColumn>(this IEnumerable<TRow> input, string field, ExpressionType binaryOperator, TColumn value)
            {
                var exp = (Func<TRow, bool>)MakeWhereLambda<TRow, TColumn>(field, binaryOperator, value).Compile();
    
                return input.Where(exp);
            }
    
            private static LambdaExpression MakeWhereLambda<TRow, TColumn>(string field, ExpressionType binaryOperator, TColumn value)
            {
                var param = Expression.Parameter(typeof(TRow), "n");
                var op = Expression.MakeBinary(binaryOperator, Expression.Property(param, field), Expression.Constant(value));
    
                return Expression.Lambda(op, new ParameterExpression[] { param });
            }
        }
    }
