    public static void AssertAllPropertiesMapped()
    {
        foreach (var map in Mapper.GetAllTypeMaps())
        {
            var propertyMaps = map.GetPropertyMaps();
            var properties = map.SourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
    
            foreach (var propertyInfo in properties)
            {
                if (!propertyMaps.Any(m => m.SourceMember == propertyInfo))
                    throw new Exception(String.Format("Property '{0}' of type '{1}' is not mapped", 
                                                      propertyInfo, map.SourceType));
            }
        }
    }
