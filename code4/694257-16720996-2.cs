    public class MyResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(
             MemberInfo member,
             MemberSerialization memberSerialization)
        {
    
            var jProperty = base.CreateProperty(member, memberSerialization);
    
            var propertyInfo = member as PropertyInfo;
            if (propertyInfo == null)
            {
                return jProperty;
            }
                
            // just adjust in case if Property name is DefaultValue
            var isDefaultValueProeprty =
                      propertyInfo.Name.Equals("DefaultValue");
    
            if(isDefaultValueProeprty)
            {
                jProperty.PropertyName = "default";
            }
                
            return jProperty;
        }
        ...
