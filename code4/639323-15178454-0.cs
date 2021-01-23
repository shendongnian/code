    public string WriteClause(Expression exp)
    {
        if (exp is ParameterExpression)
        {
            return (exp as ParameterExpression).Name;
        }
        else if (exp is BinaryExpression)
        {
            var binaryExpression = exp as BinaryExpression;
            return "(" +
                   WriteClause(binaryExpression.Left) + " "
                   GetSqlOperator(binaryExpression.Method) + " "
                   WriteClause(binaryExpression.Right) +
                   ")";
        }
        else if...
            
        ...etc...
        
    }
    
    public string GetSqlOperator(MethodInfo method)
    {
        switch (method.Name)
        {
            case "Add":
                return "+";
            case "Or":
                return "or";
            ...etc...
        }
    }
