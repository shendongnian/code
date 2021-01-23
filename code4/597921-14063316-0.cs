        var property = memberExpression.Member as PropertyInfo;
        if (property == null)
        {
        }
        var getMethod = property.GetMethod;
        if (getMethod != null && getMethod.IsStatic)
        {}
