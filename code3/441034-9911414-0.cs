    public string GetXml<T>(T instance)
    {
        var type = typeof(T);
        var properties = type.GetProperties();
        var builder = new System.Text.StringBuilder();
        
        builder.AppendFormat("<{0}>", type.Name);
    
        foreach (var property in properties)
        {
            var name = property.Name;
            var value = property.InvokeMember(name, 
                                              BindingFlags.DeclaredOnly |         
                                              BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance |
                                              BindingFlags.GetProperty,
                                              null,
                                              instance,
                                              null);
            builder.AppendFormat("<{0}>{1}</{0}>", 
                                 name,
                                 value);          
        }
    
        builder.AppendFormat("</{0}>", type.Name);
    
        return builder.ToString();
    }
