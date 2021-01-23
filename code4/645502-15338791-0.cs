    var consumerName = type.Name;
    var nameAttribute = type.GetCustomAttributes(typeof(PluginNameAttribute), true)
        .FirstOrDefault() as PluginNameAttribute;
    if (nameAttribute != null) {
        var attributeName = nameAttribute.ConsumerName;
        if (!string.IsNullOrEmpty(attributeName)) {
            consumerName = attributeName;
        }
    }
