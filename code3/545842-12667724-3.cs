    IEnumerable<PropertyInfo> MyProperties(object o)
    {
       o.GetType().GetProperties()
        .Where(p => !(p.DeclaringType is Base))
        .Where(p => p.GetCustomAttributes(false).Any(a => a is DataMemberAttribute)
    }
