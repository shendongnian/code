    public static string GetComplexPropertyName<PropertyType>(Expression<Func<T, PropertyType>> expressionForProperty)
    {
        // get the expression body
        Expression expressionBody = expressionForProperty.Body as MemberExpression;
        string expressionAsString = null;
        // all properties bar the root property will be "convert"
        switch (expressionBody.NodeType)
        {
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                UnaryExpression unaryExpression = expressionBody as UnaryExpression;
                
                if (unaryExpression != null)
                {
                    expressionAsString = unaryExpression.Operand.ToString();
                }
                
                break;
            default:
                expressionAsString = expressionBody.ToString();
                break;
        }
        // makes ure we have got an expression
        if (!String.IsNullOrWhiteSpace(expressionAsString))
        {
            // we want to get rid of the first operand as it will be the root type, so get the first occurence of "."
            int positionOfFirstDot = expressionAsString.IndexOf('.');
            if (positionOfFirstDot != -1)
            {
                return expressionAsString.Substring(positionOfFirstDot + 1, expressionAsString.Length - 1 - positionOfFirstDot);
            }
        }
        return string.Empty;
    }
