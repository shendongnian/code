    public class AccountModelRewriter : ExpressionVisitor
    {
    
        private Stack<ParameterExpression[]> _LambdaStack = new Stack<ParameterExpression[]>();
    
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            var lambda = (LambdaExpression)node;
    
            _LambdaStack.Push(
                lambda.Parameters.Select(parameter => typeof(AccountModel) == parameter.Type ? Expression.Parameter(typeof(Account)) : parameter)
                .ToArray()
            );
    
            lambda = Expression.Lambda(
                this.Visit(lambda.Body),
                _LambdaStack.Pop()
            );
    
            return lambda;
        }
    
        protected override Expression VisitMember(MemberExpression node)
        {
            var memberExpression = (MemberExpression)node;
    
            var declaringType = memberExpression.Member.DeclaringType;
            var propertyName = memberExpression.Member.Name;
    
            if (typeof(AccountModel) == declaringType)
            {
                switch (propertyName)
                {
                    case "Bal" :
                        propertyName = "Balance";
                        break;
                    case "Name" :
                        propertyName = "CustomerName";
                        break;
                }
    
                memberExpression = Expression.Property(
                    this.Visit(memberExpression.Expression),
                    typeof(Account).GetProperty(propertyName)
                );
            }
    
            return memberExpression;
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            node = (ParameterExpression)base.VisitParameter(node);
            if (typeof(AccountModel) == node.Type)
            {
                node = this._LambdaStack.Peek().Single(parameter => parameter.Type == typeof(Account));
            }
            return node;
        }
    
    }
