    var properties = this.GetType().GetRuntimeProperties();
    // or, if you want only the properties declared in this class:
    // var properties = this.GetType().GetTypeInfo().DeclaredProperties;
    foreach (var property in properties)
    {
        if (property.PropertyType == typeof(Tuple<string,string>))
        property.SetValue(this, j.GetTuple(property.Name));
    }
