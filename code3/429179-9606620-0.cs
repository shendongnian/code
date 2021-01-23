    class OptionalPropertiesContractResolver : DefaultContractResolver
    {
        //only the properties whose names are included in this list will be serialized
        IEnumerable<string> _includedProperties;
        public OptionalPropertiesContractResolver(IEnumerable<string> includedProperties)
        {
            _includedProperties = includedProperties;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return (from prop in base.CreateProperties(type, memberSerialization)
                    where _includedProperties.Contains(prop.PropertyName)
                    select prop).ToList();
        }
        protected override string ResolvePropertyName(string propertyName)
        {
            // lower case the first letter of the passed in name
            return ToCamelCase(propertyName);
        }
        static string ToCamelCase(string s)
        {
            //camel case implementation
        }
    }
