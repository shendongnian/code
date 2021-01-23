    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        if (this.IsIgnored(property.DeclaringType, property.PropertyName)
            || this.IsIgnored(property.DeclaringType, property.UnderlyingName)
            || this.IsIgnored(property.DeclaringType.BaseType, property.PropertyName)
            || this.IsIgnored(property.DeclaringType.BaseType, property.UnderlyingName))
        {
            property.ShouldSerialize = instance => { return false; };
        }
        return property;
    }
