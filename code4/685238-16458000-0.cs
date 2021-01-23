    var cleanName = element.Name.Trim('_');
    var parts = cleanName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
    var property = viewModelType.GetPropertyCaseInsensitive(parts[0]);
    var interpretedViewModelType = viewModelType;
    for (int i = 1; i < parts.Length && property != null; i++) 
    {
        interpretedViewModelType = property.PropertyType;
        property = interpretedViewModelType.GetPropertyCaseInsensitive(parts[i]);
    }
    ...etc
