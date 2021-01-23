    public static void AssertAllSourcePropertiesMapped()
    {
        foreach (var map in Mapper.GetAllTypeMaps())
        {
            // Here is hack, because source member mappings are not exposed
            Type t = typeof(TypeMap);
            var configs = t.GetField("_sourceMemberConfigs", BindingFlags.Instance | BindingFlags.NonPublic);
            var mappedSourceProperties = ((IEnumerable<SourceMemberConfig>)configs.GetValue(map)).Select(m => m.SourceMember);
            var mappedProperties = map.GetPropertyMaps().Select(m => m.SourceMember)
                                      .Concat(mappedSourceProperties);
            var properties = map.SourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
    
            foreach (var propertyInfo in properties)
            {
                if (!mappedProperties.Contains(propertyInfo))
                    throw new Exception(String.Format("Property '{0}' of type '{1}' is not mapped", 
                                                      propertyInfo, map.SourceType));
            }
        }
    }
