    public static class SqlConnectionExtensions
    {
        public static IEnumerable<T> Get<T>(this IDbConnection connection, Expression<Func<T, object>> expression) where T : class
        {
            using (connection)
            {
                connection.Open();
                var binaryExpression = (BinaryExpression)((UnaryExpression) expression.Body).Operand;
                var left = Expression.Lambda<Func<T, object>>(Expression.Convert(binaryExpression.Left, typeof(object)), expression.Parameters[0]);
                var right = binaryExpression.Right.GetType().GetProperty("Value").GetValue(binaryExpression.Right);
                var theOperator = DetermineOperator(binaryExpression);
                
                var predicate = Predicates.Field(left, theOperator, right);
                var entities = connection.GetList<T>(predicate, commandTimeout: 30);
                connection.Close();
                return entities;
            }
        }
        private static Operator DetermineOperator(Expression binaryExpression)
        {
            switch (binaryExpression.NodeType)
            {
                case ExpressionType.Equal:
                    return Operator.Eq;
                case ExpressionType.GreaterThan:
                    return Operator.Gt;
                case ExpressionType.GreaterThanOrEqual:
                    return Operator.Ge;
                case ExpressionType.LessThan:
                    return Operator.Lt;
                case ExpressionType.LessThanOrEqual:
                    return Operator.Le;
                default:
                    return Operator.Eq;
            }
        }
    }
