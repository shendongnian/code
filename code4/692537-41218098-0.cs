    public class JsonSelectiveSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var shouldSerialize = property.ShouldSerialize;
            var name = property.PropertyName;
            property.ShouldSerialize = (o) =>
            {
                var selectiveSerialize = o as ISelectiveJsonSerialize;
                if (selectiveSerialize != null)
                {
                    if (!selectiveSerialize.PropertiesToSerialize.Contains(name))
                        return false;
                }
                return shouldSerialize == null || shouldSerialize(o);
            };
            return property;
        }
    }
