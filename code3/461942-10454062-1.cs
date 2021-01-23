    public class CustomContractResolver : DefaultContractResolver
    {
        private readonly Func<bool> _includeProperty;
        public CustomContractResolver(Func<bool> includeProperty)
        {
            _includeProperty = includeProperty;
        }
        protected override JsonProperty CreateProperty(
            MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = obj => _includeProperty() &&
                                              (property.ShouldSerialize == null ||
                                               property.ShouldSerialize(obj));
            return property;
        }
    }
