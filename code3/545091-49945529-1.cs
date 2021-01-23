    private static T GetAliasedValueValue<T>(this Entity entity, string attributeName)
            {
                var attr = entity.GetAttributeValue<AliasedValue>(attributeName);
                if (attr != null)
                {
                    return (T)attr.Value;
                }
                else
                {
                    return default(T);
                }
    
            }
