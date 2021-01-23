    public class MyJsonContractResolver : DefaultContractResolver
    {
        public List<Tuple<string, string>> ExcludeProperties { get; set; }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (ExcludeProperties?.FirstOrDefault(
                s => s.Item2 == member.Name && s.Item1 == member.DeclaringType.Name) != null)
            {
                property.ShouldSerialize = instance => { return false; };
            }
            return property;
        }
    }
