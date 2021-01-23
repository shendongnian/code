    public static T GetValue<T>(this Entity entity, string attributeName)
    {
         if (entity.Attributes.ContainsKey(attributeName))
        {
            var attr = entity[attributeName];
            if (attr is AliasedValue)
            {
                return GetAliasedValueValue<T>(entity, attributeName);
            }
            else
            {
                return entity.GetAttributeValue<T>(attributeName);
            }
        }
        else
        {
            return default(T);
        }
    }
