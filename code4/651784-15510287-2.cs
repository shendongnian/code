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
            return Expression.MakeBinary(ExpressionType.AndAlso, b, binary, b.IsLiftedToNull, b.Method);
        }
    }
