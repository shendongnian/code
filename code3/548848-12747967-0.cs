    new MyExpressionVisitor().GetNumLonelyParameterExpressions(myExpression.Body)
----------
    public class MyExpressionVisitor : ExpressionVisitor
    {
        private int numLonelyParameterExpressions;
    
        public int GetNumLonelyParameterExpressions(Expression expression)
        {
            numLonelyParameterExpressions = 0;
            Visit(expression);
            return numLonelyParameterExpressions;
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            // Every time we encounter a lonely parameter, increment.
            numLonelyParameterExpressions++;
            return base.VisitParameter(node);
        }
    
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            // Don't visit parameters that have methods called on them.
             var expr = (node.Object is ParameterExpression)
                ? Expression.Default(node.Object.Type)
                : node.Object;
    
            // We need to make sure the arguments are visited though.
            return base.Visit(node.Update(expr, node.Arguments));
        }
      
      protected override Expression VisitMember(MemberExpression node)
        {
            // Don't visit parameters with member accesses on them.
            if (node.Expression is ParameterExpression)
                return Expression.Default(node.Expression.Type);
    
            return base.Visit(node);
        }
    }
