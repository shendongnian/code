    public class PublicDomainJsonContractResolverOptIn : DefaultContractResolver
    {
        public string[] AllowList { get; set; }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            properties = properties.Where(p => AllowList.Contains(p.PropertyName)).ToList();
            return properties;
        }
    }
