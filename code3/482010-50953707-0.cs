    var pairs = objectType
        .GetProperties()
        .Select(p => new {
            Property = p,
            Attribute = p
                .GetCustomAttributes(
                    typeof(JsonPropertyAttribute), true)
                .Cast<JsonPropertyAttribute>()
                .FirstOrDefault() });
    var objProps = pairs
        .Where(p => p.Attribute != null)
        .ToDictionary(
            p => p.Property.Name,
            p => p.Attribute.PropertyName);
