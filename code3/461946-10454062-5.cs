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
            var shouldSerialize = property.ShouldSerialize;
            property.ShouldSerialize = obj => _includeProperty() &&
                                              (shouldSerialize == null ||
                                               shouldSerialize(obj));
            return property;
        }
    }
