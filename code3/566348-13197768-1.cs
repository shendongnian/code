    var properties = this.GetType().GetTypeInfo().GetRuntimeProperties();
    // or
    // var properties = this.GetType().GetTypeInfo().DeclaredProperties;
    foreach (var property in properties)
    {
        if (property.PropertyType == typeof(Tuple<string,string>))
        property.SetValue(this, j.GetTuple(property.Name));
    }
