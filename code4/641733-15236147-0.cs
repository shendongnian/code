    public class ResourceNameContractResolver : 
        CamelCasePropertyNamesContractResolver
    {
        protected override IList<JsonProperty> CreateProperties CreatePropertiesInternal(Type type, MemberSerialization memberSerialization)
        {
            var list = base.CreateProperties(type, memberSerialization)
            foreach (JsonProperty p in list)
            {
                p.PropertyName = this.GetRealNameFromResourceFile(p.PropertyName);
            }
            return list;
        }
        private string GetRealNameFromResourceFile(string originalPropertyName)
        {
            // Look up name from resource file
        }
    }
