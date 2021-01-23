    public static T LoadProperty<T>(this EntityObject entity, string name) where T : new()
    {
        EntityObjectProperty prop = entity.Properties.Single(x => x.Name.Equals(name));
    
        // If request dictionary
        if (typeof(T).GetInterface(typeof(IDictionary<,>).Name) != null || typeof(T).Name.Contains("IDictionary"))
        {
            var dictionaryInstance = (IDictionary)new T();
    
            // Just for testing
            var a = dictionaryInstance.GetType().GetGenericArguments();
            Type keyType = a[0];
            Type valueType = a[1];
    
            var key = Convert.ChangeType(prop.Name, keyType);
            var value = Convert.ChangeType(prop.Value, valueType);
            dictionaryInstance.Add(key, value);
            return (T) dictionaryInstance;
        }
    
        // default
        return (T)Convert.ChangeType(prop.Value, typeof(T));
    }
