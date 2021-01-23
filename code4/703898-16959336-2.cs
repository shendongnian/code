    public object[] GetValues(Expression<Func<Person, object>> propertyNameExpression)
    {
        var compiledPropertyNameExpression = propertyNameExpression.Compile();
        if (propertyNameExpression.Body.NodeType == ExpressionType.MemberAccess)
        {
            return this.Select(compiledPropertyNameExpression).ToArray();
        }
        throw new InvalidOperationException("Invalid lambda specified. The lambda should select a property.");
    }
