    public static ModelMetadata FromLambdaExpression<TParameter, TValue(Expression<Func<TParameter, TValue>> expression, ViewDataDictionary<TParameter> viewData) {
        ...
        bool legalExpression = false; 
    
        // Need to verify the expression is valid; it needs to at least end in something
        // that we can convert to a meaningful string for model binding purposes 
    
        switch (expression.Body.NodeType) {
            // ArrayIndex always means a single-dimensional indexer; multi-dimensional indexer is a method call to Get()
            case ExpressionType.ArrayIndex: 
                legalExpression = true;
                break; 
    
            // Only legal method call is a single argument indexer/DefaultMember call
            case ExpressionType.Call: 
                legalExpression = ExpressionHelper.IsSingleArgumentIndexer(expression.Body);
                break;
    
            // Property/field access is always legal 
            case ExpressionType.MemberAccess:
                MemberExpression memberExpression = (MemberExpression)expression.Body; 
                propertyName = memberExpression.Member is PropertyInfo ? memberExpression.Member.Name : null; 
                containerType = memberExpression.Expression.Type;
                legalExpression = true; 
                break;
    
            // Parameter expression means "model => model", so we delegate to FromModel
            case ExpressionType.Parameter: 
                return FromModel(viewData);
        } 
    
        if (!legalExpression) {
            throw new InvalidOperationException(MvcResources.TemplateHelpers_TemplateLimitations); 
        }
