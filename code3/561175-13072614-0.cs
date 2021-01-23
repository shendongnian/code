    public object[] MapParameters(MethodBase method, IDictionary<string, object> namedParameters)
    {
        string[] paramNames = method.GetParameters().Select(p => p.Name).ToArray();
        object[] parameters = new object[paramNames.Length];
        foreach (var item in namedParameters)
        {
            var paramName = item.Key;
            var paramIndex = Array.IndexOf(paramNames, paramName);
            parameters[paramIndex] = item.Value;
        }
        return parameters;
    }
