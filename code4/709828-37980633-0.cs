    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        if (typeof(T).IsAssignableFrom(type) == true)
        {
            IList<JsonProperty> properties = base.CreateProperties(typeof(T), memberSerialization);
            return properties;
        }
        return base.CreateProperties(type, memberSerialization);
    }
