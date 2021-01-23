    // in DefaultParameterResolver
    public virtual object ResolveParameter(ParameterDescriptor descriptor, IJsonValue value)
    {
        // [...]
        return value.ConvertTo(descriptor.ParameterType);
    }
    // in JRawValue
    public object ConvertTo(Type type)
    {
        // A non generic implementation of ToObject<T> on JToken
        using (var jsonReader = new StringReader(_value))
        {
            var serializer = JsonUtility.CreateDefaultSerializer();
            return serializer.Deserialize(jsonReader, type);
        }
    }
    // in JsonUtility
    public static JsonSerializer CreateDefaultSerializer()
    {
        return JsonSerializer.Create(CreateDefaultSerializerSettings());
    }
    public static JsonSerializerSettings CreateDefaultSerializerSettings()
    {
        return new JsonSerializerSettings() { MaxDepth = DefaultMaxDepth };
    }
