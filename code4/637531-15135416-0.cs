    class MyVisitor : ExpressionVisitor
    {
        private readonly ConstantExpression newIdExpression;
        public MyVisitor(int newId)
        {
            this.newIdExpression = Expression.Constant(newId);
        }
        public Expression ReplaceId(Expression sourceExpression)
        {
            return Visit(sourceExpression);
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            return newIdExpression;
        }
    }
