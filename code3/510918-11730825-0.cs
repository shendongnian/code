    string propertyName = GetPropertyName(f);
    ExpressionType comp = GetComparisonType(f);
    ParameterExpression p = Expression.Parameter(typeof(OADataConsolidated));
    Expression expr =
        Expression.Lambda(
            Expression.MakeBinary(
                comp,
                Expression.Property(p, propertyName),
                Expression.Constant(value)),
            p);
            
    predicate = predicate.And(expr);
    
    
    ...
    
    static string GetPropertyName(DOTFilter filter)
    {
        switch(filter.IdValue)
        {
            case 4: // GED: Reasoning
                propertyName = "ajblGEDR_Mean";
                break;
            case 5: // GED: Mathematics
                propertyName = "ajblGEDM";
                break;
            ...
            default:
                throw new ArgumentException("Unknown Id value");
        }
    }
    
    static string GetComparisonType(DOTFilter filter)
    {
        switch (filter.Comp)
        {
            case DOTFilter.Comparitor.LessThan:
                return ExpressionType.LessThan;
            case DOTFilter.Comparitor.EqualOrLess:
                return ExpressionType.LessThanOrEqual;
            case DOTFilter.Comparitor.EqualTo:
                return ExpressionType.Equal;
            case DOTFilter.Comparitor.EqualOrGreater:
                return ExpressionType.GreaterThanOrEqual;
            case DOTFilter.Comparitor.GreaterThan:
                return ExpressionType.GreaterThan;
            default:
                throw new ArgumentException("Unknown Comp value");
        }
    }
