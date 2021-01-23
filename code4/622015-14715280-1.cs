    MemberExpression member = (MemberExpression)selector.Body;
    String propertyName = member.Member.Name;
    PropertyInfo info = typeof(T).GetProperty(propertyName, BindingFlags.Public 
                |  BindingFlags.Instance)
    return info;
