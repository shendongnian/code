    private static object GetValueFromActionContext(HttpActionContext actionContext, string key)
    {
        var queryNameValuePairs = actionContext.Request.GetQueryNameValuePairs();
        var value = queryNameValuePairs
            .Where(pair => pair.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
            .Select(pair => pair.Value)
            .FirstOrDefault();
        var methodInfo = ((ReflectedHttpActionDescriptor) (actionContext.ActionDescriptor)).MethodInfo;
        var parameters = methodInfo.GetParameters();
        var parameterType =
            parameters.Single(p => p.Name.Equals(key, StringComparison.OrdinalIgnoreCase)).ParameterType;
        var converter = TypeDescriptor.GetConverter(parameterType);
        return converter.ConvertFromString(value);
    }
