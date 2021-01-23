     private static class Cache
            {
                private static readonly IDictionary<Type, IDictionary<Type, MethodInfo>> _dict =
                    new Dictionary<Type, IDictionary<Type, MethodInfo>>();
    
                public static IDictionary<Type, MethodInfo> GetDictionaryForType(Type type)
                {
                    if (_dict.ContainsKey(type))
                    {
                        return _dict[type];
                    }
                    var dict = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                        .Where(m => m.Name == "When")
                        .Where(m => m.GetParameters().Length == 1)
                        .ToDictionary(m => m.GetParameters().First().ParameterType, m => m);
                    _dict.Add(type, dict);
                    return dict;
                }
            }
