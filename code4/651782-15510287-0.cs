    public class MyVisitor: ExpressionVisitor
    {
        private LambdaExpression visitor;
        public Expression Modify(Expression expression, LambdaExpression visitor)
        {
            this.visitor = visitor;
            return Visit(expression);
        }
        protected override Expression VisitBinary(BinaryExpression b)
        {
            var binary = visitor.Body as BinaryExpression;
            // Make this binary expression an OrElse operation instead of an AndAlso operation. 
            return Expression.MakeBinary(ExpressionType.AndAlso, b, binary, b.IsLiftedToNull, b.Method);
        }
    }
