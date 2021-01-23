    public static string GetFirstProperty(this SearchResult result,
                                          string propertyName,
                                          string defaultValue)
    {
        return result.Properties[propertyName]
                     .Cast<object>()
                     .FirstOrDefault() ?? defaultValue).ToString();
    }
