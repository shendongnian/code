    public static T LoadProperty<T>(this EntityObject entity, string name) where T : new()
    {
        EntityObjectProperty prop = entity.Properties.Single(x => x.Name.Equals(name));
    
        try
        {
            // If request dictionary
            if (typeof(T).GetInterface(typeof(IDictionary<,>).Name) != null || typeof(T).Name.Contains("IDictionary"))
            {
                var dictionaryInstance = (IDictionary)new T();
    
                var typing = dictionaryInstance.GetType().GetGenericArguments();
                Type keyType = typing[0];
                Type valueType = typing[1];
    
                // dictionary fallback, set to default of the valuetype if null
                object value = prop.Value != null ? Convert.ChangeType(prop.Value, valueType) : Activator.CreateInstance(valueType);
                var key = Convert.ChangeType(prop.Name, keyType);
                dictionaryInstance.Add(key, value);
                return (T)dictionaryInstance;
            }
    
            if (prop.Value != null)
            {
                // default
                return (T)Convert.ChangeType(prop.Value, typeof(T));
            }
        }
        catch { }
        return default(T);
    }
