    public class AddDobBindingVisitor : ExpressionVisitor
    {
        private ParameterExpression parameter;
    
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            parameter = node.Parameters.Single();
            return base.VisitLambda(node);
        }
    
        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            var member = typeof(User).GetProperty("DOB");
            var newBindings = new[]
            {
                Expression.Bind(member, Expression.Property(parameter, "DOB")),
            };
            var updatedNode = node.Update(
                node.NewExpression,
                node.Bindings.Concat(newBindings));
            return base.VisitMemberInit(updatedNode);
        }
    }
