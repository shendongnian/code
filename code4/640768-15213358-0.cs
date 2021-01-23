        public static LambdaExpression ChangeInputType<T, TResult>(Expression<Func<T, TResult>> expression, Type newInputType)
        {
            if (!typeof(T).IsAssignableFrom(newInputType))
                throw new Exception(string.Format("{0} is not assignable from {1}.", typeof(T), newInputType));
            var beforeParameter = expression.Parameters.Single();
            var afterParameter = Expression.Parameter(newInputType, beforeParameter.Name);
            var visitor = new SubstitutionExpressionVisitor(beforeParameter, afterParameter);
            return Expression.Lambda(visitor.Visit(expression.Body), afterParameter);
        }
        public static Expression<Func<T2, TResult>> ChangeInputType<T1, T2, TResult>(Expression<Func<T1, TResult>> expression)
        {
            if (!typeof(T1).IsAssignableFrom(typeof(T2)))
                throw new Exception(string.Format("{0} is not assignable from {1}.", typeof(T1), typeof(T2)));
            var beforeParameter = expression.Parameters.Single();
            var afterParameter = Expression.Parameter(typeof(T2), beforeParameter.Name);
            var visitor = new SubstitutionExpressionVisitor(beforeParameter, afterParameter);
            return Expression.Lambda<Func<T2, TResult>>(visitor.Visit(expression.Body), afterParameter);
        }
        public class SubstitutionExpressionVisitor : ExpressionVisitor
        {
            private Expression before, after;
            public SubstitutionExpressionVisitor(Expression before, Expression after)
            {
                this.before = before;
                this.after = after;
            }
            public override Expression Visit(Expression node)
            {
                return node == before ? after : base.Visit(node);
            }
        }
