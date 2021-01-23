    var call = expression.Body as MethodCallExpression;
    if (call != null)
    {
        List<object> list = new List<object>();
        foreach (Expression argument in call.Arguments)
        {
            object o = Expression.Lambda(argument, expression.Parameters).Compile().DynamicInvoke();
            list.Add(o);
        }
        StringBuilder keyValue = new StringBuilder();
        keyValue.Append(expression.Body.ToString());
        list.ForEach(e => keyValue.Append(String.Format("_{0}", e.ToString())));
        string key = keyValue.ToString();
    }
