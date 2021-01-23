    private CustomAttributeBuilder GetCustumeAttributeBuilder(Expression<Func<Attribute>> attributeExpression)
    {
        ConstructorInfo constructor = null;
        List<object> constructorArgs = new List<object>();
        List<PropertyInfo> namedProperties = new List<PropertyInfo>();
        List<object> propertyValues = new List<object>();
        List<FieldInfo> namedFields = new List<FieldInfo>();
        List<object> fieldValues = new List<object>();
        switch (attributeExpression.Body.NodeType)
        {
            case ExpressionType.New:
                constructor = GetConstructor((NewExpression)attributeExpression.Body, constructorArgs);
                break;
            case ExpressionType.MemberInit:
                MemberInitExpression initExpression = (MemberInitExpression)attributeExpression.Body;
                constructor = GetConstructor(initExpression.NewExpression, constructorArgs);
                IEnumerable<MemberAssignment> bindings = from b in initExpression.Bindings
                                                            where b.BindingType == MemberBindingType.Assignment
                                                            select b as MemberAssignment;
                foreach (MemberAssignment assignment in bindings)
                {
                    LambdaExpression lambda = Expression.Lambda(assignment.Expression);
                    object value = lambda.Compile().DynamicInvoke();
                    switch (assignment.Member.MemberType)
                    {
                        case MemberTypes.Field:
                            namedFields.Add((FieldInfo)assignment.Member);
                            fieldValues.Add(value);
                            break;
                        case MemberTypes.Property:
                            namedProperties.Add((PropertyInfo)assignment.Member);
                            propertyValues.Add(value);
                            break;
                    }
                }
                break;
            default:
                throw new ArgumentException("UnSupportedExpression", "attributeExpression");
        }
        return new CustomAttributeBuilder(
            constructor,
            constructorArgs.ToArray(),
            namedProperties.ToArray(),
            propertyValues.ToArray(),
            namedFields.ToArray(),
            fieldValues.ToArray());
    }
    private ConstructorInfo GetConstructor(NewExpression expression, List<object> constructorArgs)
    {
        foreach (Expression arg in expression.Arguments)
        {
            LambdaExpression lambda = Expression.Lambda(arg);
            object value = lambda.Compile().DynamicInvoke();
            constructorArgs.Add(value);
        }
        return expression.Constructor;
    }
