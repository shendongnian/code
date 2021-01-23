    public class IgnoreNullValuesContractResolver : DefaultRavenContractResolver
    {
        public IgnoreNullValuesContractResolver(bool shareCache)
            : base(shareCache)
        {
        }
        protected override JsonProperty CreateProperty(MemberInfo member,
                                                       MemberSerialization memberSerialization)
        {
            // Grab the property.
            var property = base.CreateProperty(member, memberSerialization);
            // Only write this property if the value is NOT null.
            // NOTE: I have no idea if this is the correct way to retrieve
            //       the reflected property and it's value. 
            property.Writable = ((PropertyInfo) member).GetValue(member, null) != null;
            return property;
        }
    }
