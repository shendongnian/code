    protected void OnPropertyChanged(Expression<Func<T, object>> property)
    {
        var propertyName = GetPropertyName(property.Body);
        if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    private static string GetPropertyName(Expression expression)
    {
        switch (expression.NodeType)
        {
            case ExpressionType.MemberAccess:
                var memberExpression = (MemberExpression)expression;
                var supername = GetPropertyName(memberExpression.Expression);
                if (String.IsNullOrEmpty(supername))
                    return memberExpression.Member.Name;
                return String.Concat(supername, '.', memberExpression.Member.Name);
            case ExpressionType.Call:
                var callExpression = (MethodCallExpression)expression;
                return callExpression.Method.Name;
            case ExpressionType.Convert:
                var unaryExpression = (UnaryExpression)expression;
                return GetPropertyName(unaryExpression.Operand);
            case ExpressionType.Parameter:
                return String.Empty;
            default:
                throw new ArgumentException();
        }
    }
