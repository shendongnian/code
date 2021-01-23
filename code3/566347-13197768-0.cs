    var properties = this.GetType().GetTypeInfo().GetProperties();
    foreach (var property in properties)
    {
        if (property.PropertyType == typeof(Tuple<string,string>))
        property.SetValue(this, j.GetTuple(property.Name));
    }
