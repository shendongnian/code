    ...
    using System.Linq.Expressions;
    ...
  
    static Delegate CreateMethod(MethodInfo method)
    {
        if (method == null)
        {
            throw new ArgumentNullException("method");
        }
        if (!method.IsStatic)
        {
            throw new ArgumentException("The provided method must be static.", "method");
        }
        if (method.IsGenericMethod)
        {
            throw new ArgumentException("The provided method must not be generic.", "method");
        }
        var parameters = method.GetParameters()
                               .Select(p => Expression.Parameter(p.ParameterType, p.Name))
                               .ToArray();
        var call = Expression.Call(null, method, parameters);
        return Expression.Lambda(call, parameters).Compile();
    }
