    public static IEnumerable<T> GetEnumValues<T>(string enumValues)
    {
        return string.IsNullOrEmpty(enumValues)
            ? Enumerable.Empty<T>()
            : enumValues.Split(',').Select(e => System.Enum.Parse(typeof(T), e.Trim(), true)).Cast<T>();
    }
    
    [ConfigurationProperty("filter")]
    public string Filter => GetEnumValues<FilterEnum>((string) this["filter"]);
