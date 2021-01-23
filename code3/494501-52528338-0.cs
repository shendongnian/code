    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
    
            if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                if (property.PropertyType.Name.StartsWith(nameof(IEnumerable)))
                    property.ShouldSerialize =
                        instance => (instance?.GetType().GetProperty(property.PropertyName).GetValue(instance) as IEnumerable<object>)?.Count() > 0;
    
            return property;
        }
    }
