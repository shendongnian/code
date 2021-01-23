    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AddContains<T>(this LambdaExpression selector, string value)
        {
            var mi = typeof (string).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Length == 1);
			
			var body = selector.GetBody().AsString();
			var x = Expression.Call(body, mi, Expression.Constant(value));
			LambdaExpression e = Expression.Lambda(x, selector.Parameters.ToArray());
			return (Expression<Func<T, bool>>)e;
		}
        public static Expression GetBody(this LambdaExpression expression)
        {
            Expression body;
            if (expression.Body is UnaryExpression)
                body = ((UnaryExpression)expression.Body).Operand;
            else
                body = expression.Body;
            return body;
        }
        public static Expression AsString(this Expression expression)
        {
            if (expression.Type == typeof (string))
                return expression;
            MethodInfo toString = typeof(SqlFunctions).GetMethods().First(m => m.Name == "StringConvert" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(double?));
            var cast = Expression.Convert(expression, typeof(double?));
            return Expression.Call(toString, cast);
        }
    }
